import axios from 'axios'
import auth from '../auth'

export const bands = {
  namespaced: true,
  state: {
    bands: [],
    currentBand: {}
  },

  getters: {
    all: state => {
      return state.bands
    },

    getCurrentBand: state => {
      return state.currentBand
    }
  },

  mutations: {
    load: (state, payload) => {
      state.bands = payload
    },

    loadCurrentBand: (state, payload) => {
      state.currentBand = payload
    },

    remove: (state, id) => {
      state.bands = state.bands.filter(el => el.id !== id)
    }
  },

  actions: {
    load: ({commit}) => {
      axios.get('/api/bands')
        .then(response => {
          commit('load', response.data)
        }).catch(e => {
        })
    },

    loadCurrentBand: ({commit}, payload) => {
      axios.get(`/api/bands/${payload}`)
        .then(response => {
          commit('loadCurrentBand', response.data)
        }).catch(e => {
        })
    },

    remove: ({commit}, payload) => {
      auth.delete(`/bands/${payload}`)
        .then(response => {
          commit('remove', payload)
        }).catch(e => {
        })
    },
    swap: ({ commit }, { first, second }) => {
      auth.put(`/bands/${first}/${second}`)
    }
  }
}
