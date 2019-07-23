import Vue from 'vue'
import moment from 'moment'

Vue.filter('uppercase', value => {
  if (!value) return ''
  value = value.toString()
  return value.toUpperCase()
})

Vue.filter('shorten', (str, length) => {
  return str.substring(0, length)
})

Vue.filter('formateDate', (str, locale) => {
  moment.locale(locale)
  const date = moment(str)
  return date.format('LL')
})

Vue.filter('formateDateTime', (str, locale) => {
  moment.locale(locale)
  const date = moment(str)
  return date.format('dddd, HH:mm')
})

Vue.filter('formateTime', (str, locale) => {
  moment.locale(locale)
  const date = moment(str)
  return date.format('HH:mm')
})
