import auth from 'utils/auth'

export const contact = {
  namespaced: true,
  state: {
    contact: []
  },

  getters: {
    all: state => {
      return state.contact
    },
    get: state => {
      return id =>
        state.contact.find(elem => {
          return elem.id === id
        })
    }
  },

  mutations: {
    load: (state, payload) => {
      state.contact = payload
    },

    remove: (state, id) => {
      state.contact = state.contact.filter(el => el.id !== id)
    }
  },

  actions: {
    load: ({ commit }) => {
      auth
        .get('ContactRequests')
        .then(response => {
          commit('load', response.data)
        })
        .catch(() => {})
    }
  }
}
