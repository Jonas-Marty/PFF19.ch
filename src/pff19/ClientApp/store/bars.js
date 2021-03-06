import axios from 'axios'
import auth from 'utils/auth'

export const bars = {
  namespaced: true,
  state: {
    bars: [],
    currentBar: {}
  },

  getters: {
    all: state => {
      return state.bars.sort((a, b) => a.order - b.order)
    },

    getCurrentBar: state => {
      return state.currentBar
    }
  },

  mutations: {
    load: (state, payload) => {
      state.bars = payload
    },

    loadCurrentBar: (state, payload) => {
      state.currentBar = payload
    },

    remove: (state, id) => {
      state.bars = state.bars.filter(el => el.id !== id)
    }
  },

  actions: {
    load: ({ commit }) => {
      axios
        .get('/api/bars')
        .then(response => {
          commit('load', response.data)
        })
        .catch(() => {})
    },

    loadCurrentBar: ({ commit }, payload) => {
      axios
        .get(`/api/bars/${payload}`)
        .then(response => {
          commit('loadCurrentBar', response.data)
        })
        .catch(() => {})
    },

    remove: ({ commit }, payload) => {
      auth
        .delete(`/bars/${payload}`)
        .then(() => {
          commit('remove', payload)
        })
        .catch(() => {})
    },
    swap: ({ first, second }) => {
      auth.put(`/bars/${first}/${second}`)
    }
  }
}
