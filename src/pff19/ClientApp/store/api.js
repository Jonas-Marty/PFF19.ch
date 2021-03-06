import axios from 'axios'
import jwtDecode from 'jwt-decode'
import router from '../router'

export const api = {
  namespaced: true,
  state: {
    idToken: null,
    userId: null,
    user: null,
    error: ''
  },
  mutations: {
    authUser(state, userData) {
      state.idToken = userData.token
      state.userId = userData.userId
    },
    storeUser(state, user) {
      state.user = user
    },
    clearAuthData(state) {
      state.idToken = null
      state.userId = null
    },
    setError(state, error) {
      state.error = error
    }
  },
  actions: {
    setLogoutTimer({ commit }, expirationTime) {
      setTimeout(() => {
        commit('clearAuthData')
      }, expirationTime)
    },
    login({ commit, dispatch }, authData) {
      axios
        .post('/api/token', {
          Mail: authData.email,
          password: authData.password,
          returnSecureToken: true
        })
        .then(res => {
          const token = jwtDecode(res.data.token)
          const expirationDate = new Date(token.exp * 1000)
          window.localStorage.setItem('token', res.data.token)
          window.localStorage.setItem('userId', token.userId)
          window.localStorage.setItem('expirationDate', expirationDate)

          commit('authUser', {
            token: res.data.token,
            userId: token.userId
          })

          router.push({ name: 'adminDashboard' })
          dispatch('setLogoutTimer', token.exp)
        })
        .catch(error => {
          commit('setError', error.response.statusText)
        })
    },
    tryAutoLogin({ commit }) {
      const token = window.localStorage.getItem('token')
      if (!token) {
        return
      }
      const expirationDate = window.localStorage.getItem('expirationDate')
      const now = new Date()
      if (now >= expirationDate) {
        return
      }
      const userId = window.localStorage.getItem('userId')
      commit('authUser', {
        token: token,
        userId: userId
      })
    },
    logout({ commit }) {
      commit('clearAuthData')
      window.localStorage.removeItem('expirationDate')
      window.localStorage.removeItem('token')
      window.localStorage.removeItem('userId')
    },
    storeUser({ state }, userData) {
      if (!state.idToken) {
        return
      }
      window.globalAxios.post('/users.json' + '?auth=' + state.idToken, userData).catch(() => {})
    },
    fetchUser({ commit, state }) {
      if (!state.idToken) {
        return
      }
      window.globalAxios
        .get('/users.json' + '?auth=' + state.idToken)
        .then(res => {
          const data = res.data
          const users = []
          for (let key in data) {
            const user = data[key]
            user.id = key
            users.push(user)
          }
          commit('storeUser', users[0])
        })
        .catch(() => {})
    }
  },
  getters: {
    user(state) {
      return state.user
    },
    isAuthenticated(state) {
      return state.idToken !== null
    },
    getToken(state) {
      return state.idToken
    },
    getError(state) {
      return state.error
    }
  }
}
