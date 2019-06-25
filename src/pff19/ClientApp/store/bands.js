import axios from 'axios'
import auth from 'utils/auth'

export const bands = {
  namespaced: true,
  state: {
    bands: [],
    currentBand: {}
  },

  getters: {
    all: state => {
      return state.bands.sort((a, b) => a.order - b.order)
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
    load: ({ commit }) => {
      axios.get('/api/bands')
        .then(response => {
          commit('load', response.data)
        }).catch(() => {
        })
    },

    loadCurrentBand: ({ commit }, payload) => {
      axios.get(`/api/bands/${payload}`)
        .then(response => {
          commit('loadCurrentBand', response.data)
        }).catch(() => {

        })
    },

    remove: ({ commit }, payload) => {
      auth.delete(`/bands/${payload}`)
        .then(() => {
          commit('remove', payload)
        }).catch(() => {
        })
    },
    swap: ({ first, second }) => {
      auth.put(`/bands/${first}/${second}`)
    }
  }
}
