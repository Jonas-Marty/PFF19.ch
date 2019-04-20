import Vue from 'vue'

Vue.filter('uppercase', value => {
    if (!value) return ''
    value = value.toString()
    return value.toUpperCase()
})

Vue.filter('shorten', (str, length) => {
    return str.substring(0, length)
})

Vue.filter('formateDate', (str, lang) => {
    const date = new Date(str)

    const day = date.getDate()
    const monthIndex = date.getMonth()
    const year = date.getFullYear()

    return day + '.' + monthIndex + '.' + year
})
