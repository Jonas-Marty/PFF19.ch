const Impressum = () => import('components/Impressum')
import HomePage from 'components/home/Home'
const Sponsors = () => import('components/sponsors/SponsorList')
import FAQ from 'components/faq/FAQ'
const Organisation = () => import('components/organisation/Organisation')
const Helfer = () => import('components/helper/Helfer')
const NewsOverview = () => import('components/news/NewsOverview')
const News = () => import('components/news/News')
const Error404 = () => 'components/partials/404'
import Contact from 'components/faq/Kontakt'
import Ticketing from 'components/ticketing/Tickets'
const Band = () => import('components/bands/Band')
const BandsOverview = () => import('components/bands/BandsOverview')
const BandsTimeTable = () => import('components/bands/BandsTimeTable')
const ProgramOverview = () => import('components/program/ProgramOverview')
const Program = () => import('components/program/Program')
const foodAndBarsOverview = () => import('components/foodAndBars/foodAndBarsOverview')
const foodAndBars = () => import('components/foodAndBars/foodAndBars')

import DefaultLayout from './layouts/Default'
const AdminLayout = () => import(/* webpackChunkName: "admin" */ './layouts/Admin')
import EmptyRouteView from './layouts/EmptyRouteView'

const Dashboard = () => import(/* webpackChunkName: "admin" */ 'components/admin/Dashboard')
const Login = () => import(/* webpackChunkName: "admin" */ 'components/admin/Login')

const Sponsoring = () =>
  import(/* webpackChunkName: "admin" */ 'components/admin/sponsoring/Sponsoring')
const SponsoringAdd = () =>
  import(/* webpackChunkName: "admin" */ 'components/admin/sponsoring/Add')
const SponsoringEdit = () =>
  import(/* webpackChunkName: "admin" */ 'components/admin/sponsoring/Edit')

const AdminNews = () => import(/* webpackChunkName: "admin" */ 'components/admin/news/News')
const AdminNewsAdd = () => import(/* webpackChunkName: "admin" */ 'components/admin/news/Add')
const AdminNewsEdit = () => import(/* webpackChunkName: "admin" */ 'components/admin/news/Edit')

const AdminFAQs = () => import(/* webpackChunkName: "admin" */ 'components/admin/faq/FAQs')
const AdminFAQAdd = () => import(/* webpackChunkName: "admin" */ 'components/admin/faq/Add')
const AdminFAQEdit = () => import(/* webpackChunkName: "admin" */ 'components/admin/faq/Edit')

const AdminBands = () => import(/* webpackChunkName: "admin" */ 'components/admin/bands/Bands')
const AdminBandsAdd = () => import(/* webpackChunkName: "admin" */ 'components/admin/bands/Add')
const AdminBandsEdit = () => import(/* webpackChunkName: "admin" */ 'components/admin/bands/Edit')

const AdminFoodAndBars = () =>
  import(/* webpackChunkName: "admin" */ 'components/admin/foodAndBars/foodAndBars')
const AdminFoodAndBarsAdd = () =>
  import(/* webpackChunkName: "admin" */ 'components/admin/foodAndBars/Add')
const AdminFoodAndBarsEdit = () =>
  import(/* webpackChunkName: "admin" */ 'components/admin/foodAndBars/Edit')

const AdminProgram = () =>
  import(/* webpackChunkName: "admin" */ 'components/admin/program/Program')
const AdminProgramAdd = () => import(/* webpackChunkName: "admin" */ 'components/admin/program/Add')
const AdminProgramEdit = () =>
  import(/* webpackChunkName: "admin" */ 'components/admin/program/Edit')

const AdminFileUpload = () =>
  import(/* webpackChunkName: "admin" */ 'components/admin/fileUpload/Files')
const AdminFileUploadAdd = () =>
  import(/* webpackChunkName: "admin" */ 'components/admin/fileUpload/Add')

const AdminHelfer = () => import(/* webpackChunkName: "admin" */ 'components/admin/helper/Helfer')
const AdminContact = () =>
  import(/* webpackChunkName: "admin" */ 'components/admin/contact/Contact')
import { store } from './store/index'

export const routes = [
  {
    name: 'default',
    component: DefaultLayout,
    path: '',
    children: [
      {
        name: 'home',
        path: '/',
        component: HomePage,
        display: 'Home',
        important: true
      },
      {
        name: 'ticketing',
        path: '/tickets',
        component: Ticketing,
        display: 'Tickets',
        important: true
      },
      {
        name: 'info',
        path: '',
        component: EmptyRouteView,
        children: [
          {
            name: 'faq',
            path: '/faq',
            component: FAQ,
            display: 'FAQ',
            important: true
          },
          {
            name: 'sponsors',
            path: '/sponsors',
            component: Sponsors,
            display: 'Sponsoren',
            important: true
          },
          {
            name: 'organisation',
            path: '/organisation',
            component: Organisation,
            display: 'Organisation',
            important: true
          }
        ]
      },
      {
        name: 'program',
        path: '',
        component: EmptyRouteView,
        children: [
          {
            name: 'bandsOverview',
            path: '/bands',
            component: BandsOverview,
            display: 'Bands',
            important: true
          },
          {
            name: 'programOverview',
            path: '/program',
            component: ProgramOverview,
            display: 'Program',
            important: true
          },
          {
            name: 'foodAndBarsOverview',
            path: '/foodandbars',
            component: foodAndBarsOverview,
            display: 'Food&Bars',
            important: true
          }
        ]
      },
      {
        name: 'helper',
        path: '/helfer',
        component: Helfer,
        display: 'Helfer',
        important: true
      },
      {
        name: 'contact',
        path: '/contact',
        component: Contact,
        display: 'Kontakt',
        important: true
      },

      {
        name: 'impressum',
        path: '/impressum',
        component: Impressum,
        display: 'Impressum'
      },
      {
        name: 'newsOverview',
        path: '/news',
        component: NewsOverview,
        display: 'NewsOverview'
      },
      {
        name: 'news',
        path: '/news/:id',
        component: News,
        display: 'News'
      },
      {
        name: 'band',
        path: '/band/:id/:name',
        component: Band,
        display: 'Band'
      },
      {
        name: 'bandWithoutId',
        path: '/band/:id',
        component: Band,
        display: 'Band'
      },
      {
        name: 'bandTimeTable',
        path: '/bands/timetable',
        component: BandsTimeTable,
        display: 'BandTimeTable'
      },
      {
        name: 'foodAndBar',
        path: '/foodandbar/:id/:name',
        component: foodAndBars,
        display: 'FoodAndBar'
      },
      {
        name: 'programDisplay',
        path: '/program/:id/:name',
        component: Program,
        display: 'Program'
      }
    ]
  },

  {
    name: 'admin',
    component: AdminLayout,
    path: '/admin',
    beforeEnter: beforeEnter,
    children: [
      {
        name: 'adminSponsoring',
        path: 'sponsoring',
        component: Sponsoring,
        display: 'Sponsoring',
        important: true
      },
      {
        name: 'adminSponsoringAdd',
        path: 'sponsoring/add',
        component: SponsoringAdd,
        display: 'ADD'
      },
      {
        name: 'adminSponsoringEdit',
        path: 'sponsoring/:id/edit',
        component: SponsoringEdit,
        display: 'EDIT'
      },
      {
        name: 'adminNews',
        path: 'news/',
        component: AdminNews,
        display: 'News',
        important: true
      },
      {
        name: 'adminNewsAdd',
        path: 'news/add',
        component: AdminNewsAdd,
        display: 'ADD'
      },
      {
        name: 'adminNewsEdit',
        path: 'news/:id/edit',
        component: AdminNewsEdit,
        display: 'EDIT'
      },
      {
        name: 'adminFAQs',
        path: 'faqs/',
        component: AdminFAQs,
        display: 'FAQs',
        important: true
      },
      {
        name: 'adminFAQAdd',
        path: 'faqs/add',
        component: AdminFAQAdd,
        display: 'ADD'
      },
      {
        name: 'adminFAQEdit',
        path: 'faqs/:id/edit',
        component: AdminFAQEdit,
        display: 'EDIT'
      },
      {
        name: 'adminBands',
        path: 'bands/',
        component: AdminBands,
        display: 'Bands',
        important: true
      },
      {
        name: 'adminBandsAdd',
        path: 'bands/add',
        component: AdminBandsAdd,
        display: 'ADD'
      },
      {
        name: 'adminBandsEdit',
        path: 'bands/:id/edit',
        component: AdminBandsEdit,
        display: 'EDIT'
      },
      {
        name: 'adminFoodAndBars',
        path: 'foodandbars',
        component: AdminFoodAndBars,
        display: 'Food&Bars',
        important: true
      },
      {
        name: 'adminFoodAndBarsAdd',
        path: 'foodandbars/add',
        component: AdminFoodAndBarsAdd,
        display: 'ADD'
      },
      {
        name: 'adminFoodAndBarsEdit',
        path: 'foodandbars/:id/edit',
        component: AdminFoodAndBarsEdit,
        display: 'EDIT'
      },
      {
        name: 'adminProgram',
        path: 'program',
        component: AdminProgram,
        display: 'Programm',
        important: true
      },
      {
        name: 'adminProgramAdd',
        path: 'program/add',
        component: AdminProgramAdd,
        display: 'ADD'
      },
      {
        name: 'adminProgramEdit',
        path: 'program/:id/edit',
        component: AdminProgramEdit,
        display: 'EDIT'
      },
      {
        name: 'adminFileUpload',
        path: 'fileupload',
        component: AdminFileUpload,
        display: 'FileUpload',
        important: true
      },
      {
        name: 'adminFileUploadAdd',
        path: 'fileupload/add',
        component: AdminFileUploadAdd,
        display: 'ADD'
      },
      {
        name: 'adminHelperList',
        path: 'helper',
        component: AdminHelfer,
        display: 'Helfer',
        important: true
      },
      {
        name: 'adminContact',
        path: 'contact/',
        component: AdminContact,
        display: 'Contact',
        important: true
      },
      {
        name: 'adminDashboard',
        path: '',
        component: Dashboard,
        display: 'Dashboard',
        important: true
      }
    ]
  },
  { name: 'login', path: '/admin/login', component: Login, display: 'Login' },

  { name: '404', path: '/*', component: Error404, display: '404' }
]

function beforeEnter(to, from, next) {
  store.dispatch('api/tryAutoLogin').then(() => {
    if (store.getters['api/isAuthenticated']) {
      next()
    } else {
      next('/admin/login')
    }
  })
}
