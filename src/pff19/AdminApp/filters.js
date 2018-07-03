import Vue from 'vue';

Vue.filter("uppercase", str => {
    return str.toUpperCase();
})