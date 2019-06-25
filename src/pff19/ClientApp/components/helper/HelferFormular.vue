<template>
  <div class="container">
    <div class="row justify-content-md-center">
      <div class="col-md-8">
        <form @submit.prevent="submit" v-if="!isSubmitted">
          <div :class="{ 'invalid-form': $v.firstname.$error }" class="form-group">
            <label for="firstname">{{ $t('lang.forms.firstname') }}*</label>
            <input
              id="firstname"
              @blur="$v.firstname.$touch()"
              v-model="firstname"
              type="text"
              class="form-control"
              placeholder="Max"
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

          <div :class="{ 'invalid-form': $v.lastname.$error }" class="form-group">
            <label for="lastname">{{ $t('lang.forms.lastname') }}*</label>
            <input
              id="lastname"
              @blur="$v.lastname.$touch()"
              v-model="lastname"
              type="text"
              name="lastname"
              class="form-control"
              placeholder="Musterman"
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

          <div :class="{ 'invalid-form': $v.scoutname.$error }" class="form-group">
            <label for="scoutname">{{ $t('lang.forms.scoutname') }}</label>
            <input
              id="scoutname"
              @blur="$v.scoutname.$touch()"
              v-model="scoutname"
              type="text"
              class="form-control"
              placeholder="Nüssli"
            />
            <div class="error-messages">
              <p v-if="!$v.scoutname.minLength && $v.scoutname.$dirty">
                {{ $t('lang.forms.errors.too-few-letters') }}
              </p>
              <p v-if="!$v.scoutname.maxLength && $v.scoutname.$dirty">
                {{ $t('lang.forms.errors.too-many-letters') }}
              </p>
            </div>
          </div>

          <div :class="{ 'invalid-form': $v.email.$error }" class="form-group">
            <label for="email">{{ $t('lang.forms.email') }}*</label>
            <input
              id="email"
              @blur="$v.email.$touch()"
              v-model="email"
              type="email"
              class="form-control"
              placeholder="max.musterman@mail.com"
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

          <div class="form-group">
            <label for="wishes">{{ $t('lang.forms.wishes') }}</label>
            <textarea
              id="wishes"
              v-model="wishes"
              rows="4"
              cols="50"
              class="form-control"
              placeholder="bar, catering ..."
            ></textarea>
          </div>

          <button type="submit" class="btn btn-primary">
            {{ $t('lang.forms.submit') }}
          </button>
        </form>

        <div v-if="isSubmitted">
          <span class="success-message">{{ $t('lang.forms.success.thx-for-register') }}</span>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import { mapGetters } from 'vuex'
import { required, email, maxLength, minLength } from 'vuelidate/lib/validators'

export default {
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

  computed: {
    ...mapGetters(['language'])
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
          .then(() => {
            this.isSubmitted = true
          })
          .catch(e => {
            this.errors.push(e)
          })
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.container {
  padding-top: 100px;
  min-height: 700px;
}
</style>
