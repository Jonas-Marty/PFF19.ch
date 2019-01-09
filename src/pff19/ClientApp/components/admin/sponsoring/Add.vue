<template>
                <div>
                    <h2 class="title">Sponsor hinzufügen</h2>
                    <div v-if="isSubmitted">
                        <p>Ein neuer Sponsor wurde hinzugefügt!</p>
                        <router-link
                        :to="{name: 'adminSponsoring'}"
                        >Zurück</router-link>
                    </div>
                   <form @submit.prevent="submit" v-if="!isSubmitted">
                    
                    <div class="form-group">
                        <label for="dropzone">Logo upload (für Gönner braucht es kein Bild) 400x150px</label>
                        <vue-dropzone ref="myVueDropzone" id="dropzone" :options="dropzoneOptions" v-on:vdropzone-file-added="sendingEvent">
                            <div class="dropzone-custom-content">
                                <h3 class="dropzone-custom-title">Drag and drop to upload content!</h3>
                                <div class="subtitle">...or click to select a file from your computer</div>
                            </div>    
                        </vue-dropzone>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.name.$error}">
                        <label for="name">Name*</label>
                        <input 
                            type="text" 
                            @blur="$v.name.$touch()" 
                            class="form-control" 
                            id="name" 
                            placeholder="Name der Firma" 
                            v-model="name"
                        >
                        <div class="error-messages">
                            <p v-if="!$v.name.required && $v.name.$dirty">Bitte einen Namen eingeben</p>
                            <p v-if="!$v.name.minLength && $v.name.$dirty">Dein Name ist zu kurz</p>
                            <p v-if="!$v.name.maxLength && $v.name.$dirty">Dein Name ist zu lang</p>
                        </div>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.link.$error}">
                        <label for="link">Link zur Firma Webseite</label>
                        <input 
                            type="text" 
                            @blur="$v.link.$touch()" 
                            class="form-control" 
                            id="link" 
                            placeholder="Der Link zur Firma" 
                            v-model="link"
                        >
                        <div class="error-messages">
                            <p v-if="!$v.link.minLength && $v.link.$dirty">Dein Link ist zu kurz</p>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="typ_of_sponsor">Sponsor Typ*</label>
                        <select
                        id="typ_of_sponsor" 
                        @blur="$v.link.$touch()"
                        class="form-control"
                        v-model="typ"
                        >
                            <option  value="3">Gönner</option>
                            <option value="2">Partner</option>
                            <option value="1">Co-Sponsor</option>
                            <option value="0">Hauptsponsor</option>
                        </select>
                    </div>


                    <button type="submit" class="btn btn-primary">Bestätigen</button>
                </form>
            </div>

</template>

<script>
import auth from '../../../auth.js'
import vue2Dropzone from 'vue2-dropzone'
import 'vue2-dropzone/dist/vue2Dropzone.min.css'
import { required, email, between, numeric, minValue, maxLength, minLength, sameAs, requiredUnless } from 'vuelidate/lib/validators'


export default {
    data () {
        return {
            errors: [],
            isSubmitted: false,
            name: '',
            link: '',
            typ: '3',
            Logo: {},

            dropzoneOptions: {
                url: '/api',
                autoProcessQueue: false,
                thumbnailWidth: 150,
                maxFilesize: 0.5,
                maxFiles: 1,
                destroyDropzone: true,
                addRemoveLinks: true,
            }

        }
    },

    components: {
        vueDropzone: vue2Dropzone,
    },

    validations: {
        name: {
            required,
            minLength: minLength(3),
            maxLength: maxLength(255)
        },
        link: {
            minLength: minLength(3),
        },
        typ: {
            required,
        },

    },

    methods: {
        submit () {
            this.$v.$touch();
            if(!this.$v.$invalid){

                const formData = {
                    Name: this.name,
                    Link: this.link,
                    Status : this.typ,
                    UploadImage: this.Logo,
                }

                let form_data = new FormData()

                for ( var key in formData ) {
                    form_data.append(key, formData[key])
                }

                auth.post('Sponsors', form_data)
                .then(response => {
                    this.isSubmitted = true;
                }).catch(e => {
                    this.errors.push(e)
                })
            }

      },

      sendingEvent (file, xhr) {
          this.Logo = file
      },

      updateDate (date) {
          this.date = date;
      }

    }

}
</script>

<style lang="scss" scoped>
    #dropzone {
        margin-bottom: 50px;
    }

    .title {
        margin-bottom: 20px;
    }

    .html-editor{
        background-color: white;
    }
</style>
