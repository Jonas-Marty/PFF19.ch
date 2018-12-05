import './css/site.scss'
import 'core-js/es6/promise'
import 'core-js/es6/array'

import { app } from './App'

require('bootstrap')

document.addEventListener('DOMContentLoaded', function () {
  app.$mount('#app')
})
