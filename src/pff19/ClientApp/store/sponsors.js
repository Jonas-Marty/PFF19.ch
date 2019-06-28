import axios from 'axios'
import auth from 'utils/auth'

export const sponsors = {
  namespaced: true,
  state: {
    sponsors: []
  },

  getters: {
    all: state => state.sponsors,
    mainSponsors: state => state.sponsors.filter(el => el.status === 0),
    coSponsors: state => state.sponsors.filter(el => el.status === 1),
    partner: state => state.sponsors.filter(el => el.status === 2),
    patronPrivatePerson: state => state.sponsors.filter(el => el.status === 3),
    infrapartner: state => state.sponsors.filter(el => el.status === 4),
    scoutpartner: state => state.sponsors.filter(el => el.status === 5),
    patronCompany: state => state.sponsors.filter(el => el.status === 6),
    withHelpFrom: state => state.sponsors.filter(el => el.status === 7),
    get: state => id => state.sponsors.find(elem => elem.id === id)
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
    load: ({ commit }) => {
      axios
        .get('/api/sponsors')
        .then(response => {
          commit('load', response.data)
        })
        .catch(() => {})
    },

    remove: ({ commit }, payload) => {
      auth
        .delete(`sponsors/${payload}`)
        .then(() => {
          commit('remove', payload)
        })
        .catch(() => {})
    }
  }
}
