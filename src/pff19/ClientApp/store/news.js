import axios from 'axios'

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
    load: (state) => {
      axios.get('/api/news')
        .then(response => {
          state.news = response.data
        }).catch(e => {
          this.errors.push(e)
        })
    }
  },

  actions: {
    load: ({commit}) => {
      commit('load')
    }
  }
}
