/**
 * Import Dependency
 */
import Vue from 'vue'
import VueI18n from 'vue-i18n'

/**
 * Import Language
 */
import de from './i18n/de_CH.json'
import fr from './i18n/fr_CH.json'

/**
 * Config
 */
Vue.use(VueI18n)

/**
 * Export
 */
export default new VueI18n({
	locale: 'de',
	fallbackLocale: 'de',
	messages: {
		de: {
			lang: de
		},
		fr: {
			lang: fr
		}
	}
})