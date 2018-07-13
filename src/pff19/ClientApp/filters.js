import Vue from 'vue';

Vue.filter("uppercase", str => {
    return str.toUpperCase();
});

Vue.filter("uppercase", (str, length) => {
    return str.substring(0,length);
})