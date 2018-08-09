<template>
    <div class="container">
        <div class="row justify-content-md-center">
            <div class="col-md-8">
                <h1>{{ $t('lang.components.faq.contact-us') }}</h1>

                <form @submit.prevent="submit" v-if="!isSubmitted">

                    <div class="form-group" :class="{'invalid-form': $v.firstname.$error}">
                        <label for="firstname">{{ $t('lang.components.helper.firstname') }}*</label>
                        <input 
                            type="text" 
                            @blur="$v.firstname.$touch()" 
                            class="form-control" 
                            id="firstname" 
                            placeholder="Max" 
                            v-model="firstname"
                        >
                        <div class="error-messages">
                            <p v-if="!$v.firstname.required && $v.firstname.$dirty">{{ $t('lang.components.helper.errors.missing-firstname') }}</p>
                            <p v-if="!$v.firstname.minLength && $v.firstname.$dirty">{{ $t('lang.components.helper.errors.too-few-letters') }}</p>
                            <p v-if="!$v.firstname.maxLength && $v.firstname.$dirty">{{ $t('lang.components.helper.errors.too-many-letters') }}</p>
                        </div>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.lastname.$error}">
                        <label for="lastname">{{ $t('lang.components.helper.lastname') }}*</label>
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
                            <p v-if="!$v.lastname.required && $v.lastname.$dirty">{{ $t('lang.components.helper.errors.missing-lastname') }}</p>
                            <p v-if="!$v.lastname.minLength && $v.lastname.$dirty">{{ $t('lang.components.helper.errors.too-few-letters') }}</p>
                            <p v-if="!$v.lastname.maxLength && $v.lastname.$dirty">{{ $t('lang.components.helper.errors.too-many-letters') }}</p>
                        </div>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.email.$error}">
                        <label for="email">{{ $t('lang.components.helper.email') }}*</label>
                        <input 
                            type="email" 
                            class="form-control" 
                            @blur="$v.email.$touch()"
                            id="email" 
                            placeholder="max.musterman@mail.com"
                            v-model="email"
                        >
                        <div class="error-messages"> 
                            <p v-if="!$v.email.required && $v.email.$dirty">{{ $t('lang.components.helper.errors.missing-email') }}</p>
                            <p v-if="!$v.email.email && $v.email.$dirty">{{ $t('lang.components.helper.errors.incorrect-email') }}</p>
                        </div>
                    </div>

                    <div class="form-group" >
                        <label for="contact-text">{{ $t('lang.components.faq.message') }}</label>
                        <textarea rows="4" cols="50" 
                            class="form-control" 
                            id="contact-text"  
                            v-model="contactText"></textarea>
                    </div>

                    <button type="submit" class="btn btn-primary" >{{ $t('lang.components.helper.submit') }}</button>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
import i18n from '../../locales';
 import { required, email, between, numeric, minValue, maxLength, minLength, sameAs, requiredUnless } from 'vuelidate/lib/validators';


export default {
    data () {
        return {
            isSubmitted: false,
            firstname: '',
            lastname: '',
            email: '',
            scoutname: '',
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
            required,
            minLength: minLength(3)
        }


    },

    methods: {
        submit () {
            this.$v.$touch();
            if(!this.$v.$invalid){
                console.log('form ok');
                this.isSubmitted = true;
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

