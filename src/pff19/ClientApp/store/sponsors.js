import axios from 'axios'
import auth from '../auth'

export const sponsors = {
  namespaced: true,
  state: {
    sponsors: []
  },

  getters: {
    all: state => {
      return state.sponsors
    },
    mainSponsors: state => {
      return state.sponsors.filter(el => el.status === 1)
    },
    get: state => {
      return id => state.sponsors.find(elem => {
        return elem.id === id
      })
    }
  },

  mutations: {
    load: (state, payload) => {
      state.sponsors = payload
    },

    remove: (state, id) => {
      state.sponsors = state.sponsors.filter(el => el.id !== id)
    }
  },

  actions: {
    load: ({commit}) => {
      axios.get('/api/sponsors')
        .then(response => {
          commit('load', response.data)
        }).catch(e => console.log(e))
    },

    remove: ({commit}, payload) => {
      auth.delete(`/sponsors/${payload}`)
        .then(r => commit('remove', payload)).catch(e => console.log(e))
    }
  }
}
