import Impressum from 'components/Impressum'
import HomePage from 'components/home/Home'
import Sponsors from 'components/sponsors/SponsorList'
import FAQ from 'components/faq/FAQ'
import Organisation from 'components/Organisation'
import Helfer from 'components/helper/Helfer'
import NewsOverview from 'components/news/NewsOverview'
import News from 'components/news/News'
import Error404 from 'components/partials/404.vue'
import Contact from 'components/faq/Kontakt'

import DefaultLayout from './layouts/Default.vue'
import AdminLayout from './layouts/Admin.vue'
import Dashboard from 'components/admin/Dashboard.vue'
import Login from 'components/admin/Login.vue'
import Sponsoring from 'components/admin/sponsoring/Sponsoring.vue'
import AdminNews from 'components/admin/news/News.vue'
import AdminNewsAdd from 'components/admin/news/Add.vue'



export const routes = [
  {name: 'default', component: DefaultLayout, path: '/',
    children: [
      { name: 'home', path: '/', component: HomePage, display: 'Home', important: true},
      { name: 'sponsors', path: '/sponsors', component: Sponsors, display: 'Sponsoren', important: false},
      { name: 'faq', path: '/faq', component: FAQ, display: 'FAQ', important: false},
      { name: 'organisation', path: '/organisation', component: Organisation, display: 'Organisation', important: true},
      { name: 'helper', path: '/helfer', component: Helfer, display: 'Helfer', important: true},


      { name: 'impressum', path: '/impressum', component: Impressum, display: 'Impressum'},
      { name: 'news_overview', path: '/news', component: NewsOverview, display: 'NewsOverview'},
      { name: 'news', path: '/news/:id', component: News, display: 'News'},
      { name: 'contact', path: '/contact', component: Contact, display: 'Kontakt', important: true}, 
    ]
  },

  {name: 'admin', component: AdminLayout, path: '/admin', //beforeEnter: beforeEnter,
      children: [
        {name: 'adminSponsoring', path: 'sponsoring', component: Sponsoring, display: 'Sponsoring'},
        {name: 'adminNews', path: 'news/', component: AdminNews, display: 'News'},
          {name: 'adminNewsAdd', path: 'news/add', component: AdminNewsAdd, display: 'add'},
        {name: 'adminHelperList', path: 'helper', component: Dashboard, display: 'Helfer'},
        {name: 'adminDashboard', path: '', component: Dashboard, display: 'Dashboard'},
      ]
    },
  {name: 'login', path: '/admin/login', component: Login, display: 'Login' },
    

{ name: '404', path: '/*', component: Error404, display: '404'}
];


function beforeEnter (to, from, next) {
    if (store.state.api.idToken) {
      next()
    } else {
      next({name: 'login'})
    }
  }