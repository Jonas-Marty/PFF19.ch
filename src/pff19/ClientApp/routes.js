import Impressum from 'components/Impressum';
import HomePage from 'components/home/Home';
import Sponsors from 'components/sponsors/SponsorList';
import FAQ from 'components/faq/FAQ';
import Organisation from 'components/Organisation';
import Helfer from 'components/helper/Helfer';
import NewsOverview from 'components/news/NewsOverview';
import News from 'components/news/News';

export const routes = [
    { name: 'home', path: '/', component: HomePage, display: 'Home', important: true},
    { name: 'sponsors', path: '/sponsors', component: Sponsors, display: 'Sponsoren', important: false},
    { name: 'faq', path: '/faq', component: FAQ, display: 'FAQ', important: true},
    { name: 'organisation', path: '/organisation', component: Organisation, display: 'Organisation', important: true},
    { name: 'helper', path: '/helfer', component: Helfer, display: 'Helfer', important: true},


    { name: 'impressum', path: '/impressum', component: Impressum, display: 'Impressum'},
    { name: 'news_overview', path: '/news', component: NewsOverview, display: 'NewsOverview'},
    { name: 'news', path: '/news/:id', component: News, display: 'News'}
];