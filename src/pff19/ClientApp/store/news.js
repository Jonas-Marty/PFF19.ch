import axios from 'axios'
import auth from '../auth'

export const news = {
  namespaced: true,
  state: {
    news: []
  },

  getters: {
    all: state => {
      return state.news
    },
    get: state => {
      return id => state.news.find(elem => {
        return elem.id === id
      })
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
      axios.get('/api/news')
        .then(response => {
          commit('load', response.data)
        }).catch(e => {
        })
    },

    remove: ({commit}, payload) => {
      auth.delete(`/news/${payload}`)
        .then(response => {
          commit('remove', payload)
        }).catch(e => {
        })
    }
  }
}
