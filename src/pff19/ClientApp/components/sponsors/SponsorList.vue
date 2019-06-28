<template>
  <div class="container">
    <text-de v-if="language === 'de'"></text-de>
    <text-fr v-if="language === 'fr'"></text-fr>
    <div v-if="mainSponsors && mainSponsors.length > 0" class="sponsors">
      <h2>{{ $t('lang.components.home.sponsors.main_sponsors') }}</h2>
      <div class="row">
        <app-sponsor
          v-for="sponsor in mainSponsors"
          :key="sponsor.id"
          :sponsor="sponsor"
        ></app-sponsor>
      </div>
    </div>

    <div v-if="coSponsors && coSponsors.length > 0" class="sponsors">
      <h2>{{ $t('lang.components.home.sponsors.co_sponsors') }}</h2>
      <div class="row">
        <app-sponsor
          v-for="sponsor in coSponsors"
          :key="sponsor.id"
          :sponsor="sponsor"
        ></app-sponsor>
      </div>
    </div>

    <div v-if="partner && partner.length > 0" class="sponsors">
      <h2>{{ $t('lang.components.home.sponsors.partner') }}</h2>
      <div class="row">
        <app-sponsor v-for="sponsor in partner" :key="sponsor.id" :sponsor="sponsor"></app-sponsor>
      </div>
    </div>

    <div v-if="infrapartner && infrapartner.length > 0" class="sponsors">
      <h2>{{ $t('lang.components.home.sponsors.infrapartner') }}</h2>
      <div class="row">
        <app-sponsor
          v-for="sponsor in infrapartner"
          :key="sponsor.id"
          :sponsor="sponsor"
        ></app-sponsor>
      </div>
    </div>

    <div v-if="scoutpartner && scoutpartner.length > 0" class="sponsors">
      <h2>{{ $t('lang.components.home.sponsors.scoutpartner') }}</h2>
      <div class="row">
        <app-sponsor
          v-for="sponsor in scoutpartner"
          :key="sponsor.id"
          :sponsor="sponsor"
        ></app-sponsor>
      </div>
    </div>

    <div v-if="withHelpFrom && withHelpFrom.length > 0" class="sponsors">
      <h2>{{ $t('lang.components.home.sponsors.withHelpFrom') }}</h2>
      <div class="row">
        <app-sponsor
          v-for="helper in withHelpFrom"
          :key="helper.id"
          :sponsor="helper"
        ></app-sponsor>
      </div>
    </div>

    <div v-if="patronCompany && patronCompany.length > 0" class="sponsors">
      <h2>{{ $t('lang.components.home.sponsors.patron_company') }}</h2>
      <div class="row">
        <goenner
          v-for="sponsor in patronCompanySorted"
          :key="sponsor.id"
          :sponsor="sponsor"
        ></goenner>
      </div>
    </div>

    <div v-if="patronPrivatePerson && patronPrivatePerson.length > 0" class="sponsors">
      <h2>{{ $t('lang.components.home.sponsors.patron_private_person') }}</h2>
      <div class="row">
        <goenner
          v-for="sponsor in patronPrivatePerson"
          :key="sponsor.id"
          :sponsor="sponsor"
        ></goenner>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import Sponsor from './Sponsor'
import Goenner from './Goenner'
import textDe from './TextDe'
import textFr from './TextFr'

export default {
  metaInfo() {
    return {
      title: `| ${this.$i18n.t('lang.navigation.sponsors')}`
    }
  },

  components: {
    'app-sponsor': Sponsor,
    Goenner,
    textFr,
    textDe
  },
  computed: {
    ...mapGetters('sponsors', [
      'mainSponsors',
      'coSponsors',
      'partner',
      'patronCompany',
      'patronPrivatePerson',
      'infrapartner',
      'scoutpartner',
      'withHelpFrom'
    ]),

    ...mapGetters(['language']),

    patronCompanySorted() {
      // eslint-disable-next-line vue/no-side-effects-in-computed-properties
      return this.patronCompany.sort((a, b) => a.name.localeCompare(b.name))
    },

    patronPrivatePersonSorted() {
      // eslint-disable-next-line vue/no-side-effects-in-computed-properties
      return this.patronPrivatePerson.sort((a, b) => a.name.localeCompare(b.name))
    }
  },

  created() {
    this.load()
  },
  methods: {
    ...mapActions('sponsors', ['load'])
  }
}
</script>

<style lang="scss" scoped>
.container {
  padding-top: 100px;
  min-height: 700px;
}

.sponsors {
  width: 100%;
  margin-top: 50px;
}
</style>
