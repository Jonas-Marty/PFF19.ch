import Impressum from 'components/Impressum'
import HomePage from 'components/home/Home'
import Sponsors from 'components/sponsors/SponsorList'
import FAQ from 'components/faq/FAQ'
import Organisation from 'components/organisation/Organisation'
import Helfer from 'components/helper/Helfer'
import NewsOverview from 'components/news/NewsOverview'
import News from 'components/news/News'
import Error404 from 'components/partials/404'
import Contact from 'components/faq/Kontakt'
import Ticketing from 'components/ticketing/Tickets'

import DefaultLayout from './layouts/Default'
import AdminLayout from './layouts/Admin'
import Dashboard from 'components/admin/Dashboard'
import Login from 'components/admin/Login'
import Sponsoring from 'components/admin/sponsoring/Sponsoring'
import SponsoringAdd from 'components/admin/sponsoring/Add'
import SponsoringEdit from 'components/admin/sponsoring/Edit'
import AdminNews from 'components/admin/news/News'
import AdminNewsAdd from 'components/admin/news/Add'
import AdminNewsEdit from 'components/admin/news/Edit'
import AdminFAQs from 'components/admin/faq/FAQs'
import AdminFAQAdd from 'components/admin/faq/Add'
// import AdminFAQEdit from 'components/admin/faq/Edit'
import AdminBands from 'components/admin/bands/Bands'
import AdminBandsAdd from 'components/admin/bands/Add'
import AdminBandsEdit from 'components/admin/bands/Edit'

import AdminHelfer from 'components/admin/helper/Helfer'
import AdminContact from 'components/admin/contact/Contact'
import { store } from './store/index'

export const routes = [
  {name: 'default',
    component: DefaultLayout,
    path: '/',
    children: [
      { name: 'home', path: '/', component: HomePage, display: 'Home', important: true },
      { name: 'sponsors', path: '/sponsors', component: Sponsors, display: 'Sponsoren', important: false },
      { name: 'faq', path: '/faq', component: FAQ, display: 'FAQ', important: true },
      { name: 'organisation', path: '/organisation', component: Organisation, display: 'Organisation', important: true },
      { name: 'helper', path: '/helfer', component: Helfer, display: 'Helfer', important: true },

      { name: 'impressum', path: '/impressum', component: Impressum, display: 'Impressum' },
      { name: 'news_overview', path: '/news', component: NewsOverview, display: 'NewsOverview' },
      { name: 'news', path: '/news/:id', component: News, display: 'News' },
      { name: 'contact', path: '/contact', component: Contact, display: 'Kontakt', important: true },
      { name: 'ticketing', path: '/tickets', component: Ticketing, display: 'Tickets', important: false }
    ]
  },

  {name: 'admin',
    component: AdminLayout,
    path: '/admin',
    beforeEnter: beforeEnter,
    children: [
      {name: 'adminSponsoring', path: 'sponsoring', component: Sponsoring, display: 'Sponsoring', important: true},
      {name: 'adminSponsoringAdd', path: 'sponsoring/add', component: SponsoringAdd, display: 'ADD'},
      {name: 'adminSponsoringEdit', path: 'sponsoring/:id/edit', component: SponsoringEdit, display: 'EDIT'},
      {name: 'adminNews', path: 'news/', component: AdminNews, display: 'News', important: true},
      {name: 'adminNewsAdd', path: 'news/add', component: AdminNewsAdd, display: 'ADD'},
      {name: 'adminNewsEdit', path: 'news/:id/edit', component: AdminNewsEdit, display: 'EDIT'},
      {name: 'adminFAQs', path: 'faqs/', component: AdminFAQs, display: 'FAQs', important: false},
      {name: 'adminFAQAdd', path: 'faqs/add', component: AdminFAQAdd, display: 'ADD'},
      // {name: 'adminFsAQEdit', path: 'faqs/:order/edit', component: AdminFAQEdit, display: 'EDIT'},
      {name: 'adminBands', path: 'bands/', component: AdminBands, display: 'Bands', important: true},
      {name: 'adminBandsAdd', path: 'bands/add', component: AdminBandsAdd, display: 'ADD'},
      {name: 'adminBandsEdit', path: 'bands/:id/edit', component: AdminBandsEdit, display: 'EDIT'},
      {name: 'adminHelperList', path: 'helper', component: AdminHelfer, display: 'Helfer', important: true},
      {name: 'adminContact', path: 'contact/', component: AdminContact, display: 'Contact', important: true},
      {name: 'adminDashboard', path: '', component: Dashboard, display: 'Dashboard', important: true}
    ]
  },
  { name: 'login', path: '/admin/login', component: Login, display: 'Login' },

  { name: '404', path: '/*', component: Error404, display: '404' }
]

function beforeEnter (to, from, next) {
  store.dispatch('api/tryAutoLogin').then(() => {
    if (store.getters['api/isAuthenticated']) {
      next()
    } else {
      next('/admin/login')
    }
  })
}
