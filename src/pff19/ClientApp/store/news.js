import axios from 'axios'
import auth from 'utils/auth'

export const news = {
  namespaced: true,
  state: {
    news: [],
    currentNews: {}
  },

  getters: {
    all: state => {
      return state.news
    },

    getCurrentNews: state => {
      return state.currentNews
    },

    firstThree: state => {
      return state.news.slice(0, 3)
    }
  },

  mutations: {
    load: (state, payload) => {
      state.news = payload
    },

    loadCurrentNews: (state, payload) => {
      state.currentNews = payload
    },

    remove: (state, id) => {
      state.news = state.news.filter(el => el.id !== id)
    }
  },

  actions: {
    load: ({ commit }) => {
      axios
        .get('/api/news')
        .then(response => {
          commit('load', response.data)
        })
        .catch(() => {})
    },

    loadTopThree: ({ commit }) => {
      axios
        .get('/api/news/top')
        .then(response => {
          commit('load', response.data)
        })
        .catch(() => {})
    },

    loadCurrentNews: ({ commit }, payload) => {
      axios
        .get(`/api/news/${payload}`)
        .then(response => {
          commit('loadCurrentNews', response.data)
        })
        .catch(() => {})
    },

    remove: ({ commit }, payload) => {
      auth
        .delete(`/news/${payload}`)
        .then(() => {
          commit('remove', payload)
        })
        .catch(() => {})
    }
  }
}
