<template>
  <div class="container-fluid contact">
    <app-polygon color="yellow" position="left"></app-polygon>
    <div class="container">
      <div class="row justify-content-md-center">
        <div class="col-md-8">
          <h1>{{ $t('lang.components.faq.contact-us') }}</h1>

          <p>{{ $t('lang.components.faq.contact-text') }}</p>

          <form @submit.prevent="submit" v-if="!isSubmitted">
            <div class="form-group" :class="{ 'invalid-form': $v.firstname.$error }">
              <label for="firstname">{{ $t('lang.forms.firstname') }}*</label>
              <input
                type="text"
                @blur="$v.firstname.$touch()"
                class="form-control"
                id="firstname"
                placeholder="Max"
                v-model="firstname"
              />
              <div class="error-messages">
                <p v-if="!$v.firstname.required && $v.firstname.$dirty">
                  {{ $t('lang.forms.errors.missing-firstname') }}
                </p>
                <p v-if="!$v.firstname.minLength && $v.firstname.$dirty">
                  {{ $t('lang.forms.errors.too-few-letters') }}
                </p>
                <p v-if="!$v.firstname.maxLength && $v.firstname.$dirty">
                  {{ $t('lang.forms.errors.too-many-letters') }}
                </p>
              </div>
            </div>

            <div class="form-group" :class="{ 'invalid-form': $v.lastname.$error }">
              <label for="lastname">{{ $t('lang.forms.lastname') }}*</label>
              <input
                type="text"
                @blur="$v.lastname.$touch()"
                name="lastname"
                class="form-control"
                id="lastname"
                placeholder="Musterman"
                v-model="lastname"
              />
              <div class="error-messages">
                <p v-if="!$v.lastname.required && $v.lastname.$dirty">
                  {{ $t('lang.forms.errors.missing-lastname') }}
                </p>
                <p v-if="!$v.lastname.minLength && $v.lastname.$dirty">
                  {{ $t('lang.forms.errors.too-few-letters') }}
                </p>
                <p v-if="!$v.lastname.maxLength && $v.lastname.$dirty">
                  {{ $t('lang.forms.errors.too-many-letters') }}
                </p>
              </div>
            </div>

            <div class="form-group" :class="{ 'invalid-form': $v.email.$error }">
              <label for="email">{{ $t('lang.forms.email') }}*</label>
              <input
                type="email"
                class="form-control"
                @blur="$v.email.$touch()"
                id="email"
                placeholder="max.musterman@mail.com"
                v-model="email"
              />
              <div class="error-messages">
                <p v-if="!$v.email.required && $v.email.$dirty">
                  {{ $t('lang.forms.errors.missing-email') }}
                </p>
                <p v-if="!$v.email.email && $v.email.$dirty">
                  {{ $t('lang.forms.errors.incorrect-email') }}
                </p>
              </div>
            </div>

            <div class="form-group" :class="{ 'invalid-form': $v.contactText.$error }">
              <label for="contact-text">{{ $t('lang.forms.message') }}</label>
              <textarea
                rows="4"
                cols="50"
                @blur="$v.contactText.$touch()"
                class="form-control"
                id="contact-text"
                v-model="contactText"
              ></textarea>

              <div class="error-messages">
                <p v-if="!$v.contactText.required && $v.contactText.$dirty">
                  {{ $t('lang.forms.errors.missing-message') }}
                </p>
              </div>
            </div>

            <button type="submit" class="btn btn-primary">
              {{ $t('lang.forms.submit') }}
            </button>
          </form>

          <div v-if="isSubmitted">
            <span class="success-message">
              {{ $t('lang.forms.success.contact-confirm') }}
            </span>
          </div>
          <div class="account-infos">
            {{ $t('lang.components.faq.account') }}:
            <p>
              CH98 0070 0110 0062 5243 7
              <br />PFF Stäfa 2019 <br />8712 Stäfa
            </p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import i18n from '../../locales'
import axios from 'axios'

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
      title: `| ${this.$i18n.t('lang.navigation.contact')}`
    }
  },
  data() {
    return {
      isSubmitted: false,
      firstname: '',
      lastname: '',
      email: '',
      contactText: ''
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
    email: {
      required,
      email
    },
    contactText: {
      required
    }
  },

  methods: {
    submit() {
      this.$v.$touch()
      if (!this.$v.$invalid) {
        const formData = {
          firstname: this.firstname,
          lastname: this.lastname,
          mail: this.email,
          text: this.contactText
        }

        axios
          .post('/api/ContactRequests', formData)
          .then(response => {
            this.isSubmitted = true
          })
          .catch(e => {
            this.errors.push(e)
          })
      }

      //this.$store.dispatch('signup', formData)
    }
  }
}
</script>

<style lang="scss" scoped>
.contact {
  position: relative;
}
.container {
  padding-top: 100px;
  min-height: 750px;
}
.account-infos {
  margin-top: 40px;
}
</style>
