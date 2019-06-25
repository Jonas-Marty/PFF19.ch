import axios from "axios";
import auth from "utils/auth";

export const faqs = {
  namespaced: true,
  state: {
    faqs: []
  },

  getters: {
    all: state => {
      return state.faqs;
    }
  },

  mutations: {
    load: (state, payload) => {
      state.faqs = payload;
    },

    remove: (state, id) => {
      state.faqs = state.faqs.filter(el => el.id !== id);
    }
  },

  actions: {
    load: ({ commit }) => {
      axios
        .get("/api/faq")
        .then(response => {
          commit("load", response.data);
        })
        .catch(e => {});
    },

    remove: ({ commit }, payload) => {
      auth
        .delete(`/faq/${payload}`)
        .then(response => {
          commit("remove", payload);
        })
        .catch(e => {});
    },
    swap: ({ commit }, { first, second }) => {
      auth.put(`/faq/${first}/${second}`);
    }
  }
};
