<template>
  <div class="padding-top">
    <slideshow></slideshow>
    <div class="container">
      <div class="row justify-content-md-center">
        <div class="col-md-8">
          <h1>{{ $t('lang.components.helper.helper') }}</h1>
          <text-de v-if="language === 'de'"></text-de>
          <text-fr v-if="language === 'fr'"></text-fr>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import i18n from '../../locales'
import axios from 'axios'
import { mapGetters } from 'vuex'
import textDe from './TextDe'
import textFr from './TextFr'
import Slideshow from './Slideshow'

import {
    required,
    email,
    between,
    numeric,
    minValue,
    maxLength,
    minLength,
    sameAs,
    requiredUnless
} from 'vuelidate/lib/validators'

export default {
    metaInfo() {
        return {
            title: `| ${this.$i18n.t('lang.navigation.helper')}`
        }
    },
    data() {
        return {
            isSubmitted: false,
            firstname: '',
            lastname: '',
            email: '',
            scoutname: '',
            wishes: ''
        }
    },

    validations: {
        firstname: {
            required,
            minLength: minLength(3),
            maxLength: maxLength(255)
        },
        lastname: {
            required,
            minLength: minLength(3),
            maxLength: maxLength(255)
        },
        scoutname: {
            minLength: minLength(3),
            maxLength: maxLength(255)
        },
        email: {
            required,
            email
        }
    },

    methods: {
        submit() {
            this.$v.$touch()
            if (!this.$v.$invalid) {
                const formData = {
                    name: this.firstname,
                    vorname: this.lastname,
                    email: this.email,
                    pfadiname: this.scoutname,
                    wishes: this.wishes
                }

                axios
                    .post('/api/Assistants', formData)
                    .then(response => {
                        this.isSubmitted = true
                    })
                    .catch(e => {
                        this.errors.push(e)
                    })
            }
        }
    },

    computed: {
        ...mapGetters(['language'])
    },

    components: {
        textDe,
        textFr,
        Slideshow
    }
}
</script>

<style lang="scss" scoped>
.container {
    padding-top: 50px;
    min-height: 500px;
}

.padding-top {
    padding-top: 50px;
}
</style>
