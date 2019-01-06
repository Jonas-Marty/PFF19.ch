import axios from 'axios'
import auth from '../auth'

export const bands = {
  namespaced: true,
  state: {
    bands: []
  },

  getters: {
    all: state => {
      return state.news
    }
  },

  mutations: {
    load: (state, payload) => {
      state.news = payload
    },

    remove: (state, id) => {
      state.news = state.news.filter(el => el.id !== id)
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

    remove: ({commit}, payload) => {
      auth.delete(`/bands/${payload}`)
        .then(response => {
          commit('remove', payload)
        }).catch(e => {
        })
    }
  }
}
