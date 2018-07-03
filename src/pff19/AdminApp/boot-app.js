import './css/site.scss'
import 'core-js/es6/promise'
import 'core-js/es6/array'

window.$ = window.jQuery = require('jquery');
require('bootstrap');

import { app } from './App'

app.$mount('#app')
