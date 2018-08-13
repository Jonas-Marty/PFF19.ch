<template>
    <div class="container">
        <div class="row justify-content-md-center">
            <div class="col-md-8">
                <h1>{{ $t('lang.components.helper.helper') }}</h1>

                <p>
                Hast du Interesse am PFF19 als Helfer mitzuwirken? Dann fülle bitte das untenstehende Formular aus.
                So können wir dich vor allen anderen informieren, wenn wir unser Helfertool aufschalten (ca. Frühjahr 2019).
                Beachte bitte, dass dies keine definitive Anmeldung als Helfer ist. Bei allgemeinen Fragen wende dich
                bitte an <b>info@pff19.ch</b>.
                </p>

                <form @submit.prevent="submit" v-if="!isSubmitted">

                    <div class="form-group" :class="{'invalid-form': $v.firstname.$error}">
                        <label for="firstname">{{ $t('lang.forms.firstname') }}*</label>
                        <input 
                            type="text" 
                            @blur="$v.firstname.$touch()" 
                            class="form-control" 
                            id="firstname" 
                            placeholder="Max" 
                            v-model="firstname"
                        >
                        <div class="error-messages">
                            <p v-if="!$v.firstname.required && $v.firstname.$dirty">{{ $t('lang.forms.errors.missing-firstname') }}</p>
                            <p v-if="!$v.firstname.minLength && $v.firstname.$dirty">{{ $t('lang.forms.errors.too-few-letters') }}</p>
                            <p v-if="!$v.firstname.maxLength && $v.firstname.$dirty">{{ $t('lang.forms.errors.too-many-letters') }}</p>
                        </div>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.lastname.$error}">
                        <label for="lastname">{{ $t('lang.forms.lastname') }}*</label>
                        <input 
                            type="text" 
                            @blur="$v.lastname.$touch()" 
                            name="lastname" 
                            class="form-control" 
                            id="lastname" 
                            placeholder="Musterman" 
                            v-model="lastname"
                        >
                        <div class="error-messages">
                            <p v-if="!$v.lastname.required && $v.lastname.$dirty">{{ $t('lang.forms.errors.missing-lastname') }}</p>
                            <p v-if="!$v.lastname.minLength && $v.lastname.$dirty">{{ $t('lang.forms.errors.too-few-letters') }}</p>
                            <p v-if="!$v.lastname.maxLength && $v.lastname.$dirty">{{ $t('lang.forms.errors.too-many-letters') }}</p>
                        </div>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.scoutname.$error}">
                        <label for="scoutname">{{ $t('lang.forms.scoutname') }}</label>
                        <input 
                            type="text" 
                            @blur="$v.scoutname.$touch()" 
                            class="form-control" 
                            id="scoutname" 
                            placeholder="Nüssli" 
                            v-model="scoutname"
                        >
                        <div class="error-messages"> 
                            <p v-if="!$v.scoutname.minLength && $v.scoutname.$dirty">{{ $t('lang.forms.errors.too-few-letters') }}</p>
                            <p v-if="!$v.scoutname.maxLength && $v.scoutname.$dirty">{{ $t('lang.forms.errors.too-many-letters') }}</p>
                        </div>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.email.$error}">
                        <label for="email">{{ $t('lang.forms.email') }}*</label>
                        <input 
                            type="email" 
                            class="form-control" 
                            @blur="$v.email.$touch()"
                            id="email" 
                            placeholder="max.musterman@mail.com"
                            v-model="email"
                        >
                        <div class="error-messages"> 
                            <p v-if="!$v.email.required && $v.email.$dirty">{{ $t('lang.forms.errors.missing-email') }}</p>
                            <p v-if="!$v.email.email && $v.email.$dirty">{{ $t('lang.forms.errors.incorrect-email') }}</p>
                        </div>
                    </div>

                    <div class="form-group" >
                        <label for="wishes">{{ $t('lang.forms.wishes') }}</label>
                        <textarea rows="4" cols="50" class="form-control" id="wishes" placeholder="bar, catering ..." v-model="wishes"></textarea>
                    </div>

                    <button type="submit" class="btn btn-primary" >{{ $t('lang.forms.submit') }}</button>
                </form>

                <div v-if="isSubmitted">
                    <span class="success-message">{{ $t('lang.forms.success.thx-for-register') }}</span>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import i18n from '../../locales';
import axios from 'axios';

 import { required, email, between, numeric, minValue, maxLength, minLength, sameAs, requiredUnless } from 'vuelidate/lib/validators';


export default {
    data () {
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
        submit () {
            this.$v.$touch();
            if(!this.$v.$invalid){

                const formData = {
                    name: this.firstname,
                    vorname: this.lastname,
                    email: this.email,
                    pfadiname: this.scoutname,
                    wishes: this.wishes
                }

                axios.post('/api/Assistants', formData)
                .then(response => {
                    this.isSubmitted = true;
                }).catch(e => {
                    this.errors.push(e)
                });

            }
        //this.$store.dispatch('signup', formData)
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

