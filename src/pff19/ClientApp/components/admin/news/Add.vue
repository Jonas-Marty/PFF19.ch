<template>
                <div>
                    <h2 class="title">News hinzufügen</h2>
                    <div v-if="isSubmitted">
                        <p>Deine News wurde hinzugefügt!</p>
                        <router-link
                        :to="{name: 'adminNews'}"
                        >Zurück</router-link>
                    </div>
                   <form @submit.prevent="submit" v-if="!isSubmitted">
                    
                    <div class="form-group">
                        <label for="title_de">Image upload</label>
                        <vue-dropzone ref="myVueDropzone" id="dropzone" :options="dropzoneOptions" v-on:vdropzone-sending="sendingEvent">
                            <div class="dropzone-custom-content">
                                <h3 class="dropzone-custom-title">Drag and drop to upload content!</h3>
                                <div class="subtitle">...or click to select a file from your computer</div>
                            </div>    
                        </vue-dropzone>   
                    </div>
                    <div class="form-group">
                        <label for="select_date">Date</label>
                        <datepicker @selected="updateDate" :value="date" bootstrap-styling></datepicker>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.TitleDe.$error}">
                        <label for="title_de">Titel in Deutsch</label>
                        <input 
                            type="text" 
                            @blur="$v.TitleDe.$touch()" 
                            class="form-control" 
                            id="title_de" 
                            placeholder="Dein Title in Deutsch" 
                            v-model="TitleDe"
                        >
                        <div class="error-messages">
                            <p v-if="!$v.TitleDe.required && $v.TitleDe.$dirty">Bitte ein Titel eingeben</p>
                            <p v-if="!$v.TitleDe.minLength && $v.TitleDe.$dirty">Dein Titel ist zu kurz</p>
                            <p v-if="!$v.TitleDe.maxLength && $v.TitleDe.$dirty">Dein Titel ist zu lang</p>
                        </div>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.TitleFr.$error}">
                        <label for="title_fr">Titel Französisch</label>
                        <input 
                            type="text" 
                            @blur="$v.TitleFr.$touch()" 
                            class="form-control" 
                            id="title_fr" 
                            placeholder="Dein Title in Französisch" 
                            v-model="TitleFr"
                        >
                        <div class="error-messages">
                            <p v-if="!$v.TitleFr.required && $v.TitleFr.$dirty">Bitte ein Titel eingeben</p>
                            <p v-if="!$v.TitleFr.minLength && $v.TitleFr.$dirty">Dein Titel ist zu kurz</p>
                            <p v-if="!$v.TitleFr.maxLength && $v.TitleFr.$dirty">Dein Titel ist zu lang</p>
                        </div>
                    </div>


                    <div class="form-group" :class="{'invalid-form': $v.PreviewDe.$error}">
                        <label for="preview_de">Preview Deutsch</label>
                        <textarea 
                            type="text" 
                            @blur="$v.PreviewDe.$touch()" 
                            class="form-control" 
                            id="preview_de" 
                            placeholder="Deine Preview" 
                            v-model="PreviewDe"
                        > </textarea>
                        <div class="error-messages">
                            <p v-if="!$v.PreviewDe.required && $v.PreviewDe.$dirty">Bitte eine Preview eingeben</p>
                            <p v-if="!$v.PreviewDe.minLength && $v.PreviewDe.$dirty">Deine Preview ist zu kurz</p>
                            <p v-if="!$v.PreviewDe.maxLength && $v.PreviewDe.$dirty">Deine Preview ist zu lang</p>
                        </div>
                    </div>

                      <div class="form-group" :class="{'invalid-form': $v.PreviewFr.$error}">
                        <label for="preview_fr">Preview Französisch</label>
                        <textarea 
                            type="text" 
                            @blur="$v.PreviewFr.$touch()" 
                            class="form-control" 
                            id="preview_fr" 
                            placeholder="Deine Preview in Französisch" 
                            v-model="PreviewFr"
                        > </textarea>
                        <div class="error-messages">
                            <p v-if="!$v.PreviewFr.required && $v.PreviewFr.$dirty">Bitte eine Preview eingeben</p>
                            <p v-if="!$v.PreviewFr.minLength && $v.PreviewFr.$dirty">Deine Preview ist zu kurz</p>
                            <p v-if="!$v.PreviewFr.maxLength && $v.PreviewFr.$dirty">Deine Preview ist zu lang</p>
                        </div>
                    </div>


                    <div class="form-group" :class="{'invalid-form': $v.ContentDe.$error}">
                        <label for="content_de">Inhalt Deutsch</label>
                        <vue-editor class="html-editor" @blur="$v.ContentDe.$touch()" id="contentd_de"  v-model="ContentDe"></vue-editor>

                        <div class="error-messages"> 
                            <p v-if="!$v.ContentDe.required && $v.ContentDe.$dirty">Es brauch einen Inhalt für deine News</p>
                        </div>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.ContentFr.$error}">
                        <label for="content_fr">Inhalt Französisch</label>
                        <vue-editor class="html-editor" @blur="$v.ContentFr.$touch()" id="contentd_fr"  v-model="ContentFr"></vue-editor>

                        <div class="error-messages"> 
                            <p v-if="!$v.ContentFr.required && $v.ContentFr.$dirty">Es brauch einen Inhalt für deine News</p>
                        </div>
                    </div>

                    <button type="submit" class="btn btn-primary" >Bestätigen</button>
                </form>
            </div>

</template>

<script>
import auth from '../../../auth.js'
import vue2Dropzone from 'vue2-dropzone'
import { VueEditor } from "vue2-editor"
import Datepicker from 'vuejs-datepicker'
import 'vue2-dropzone/dist/vue2Dropzone.min.css'
import { required, email, between, numeric, minValue, maxLength, minLength, sameAs, requiredUnless } from 'vuelidate/lib/validators'


export default {
    data () {
        return {
            errors: [],
            isSubmitted: false,
            TitleDe: '',
            TitleFr: '',
            PreviewDe: '',
            PreviewFr: '',
            ContentDe: '',
            ContentFr: '',
            Image: {},
            date: new Date(),

            dropzoneOptions: {
                url: '/api',
                thumbnailWidth: 150,
                maxFilesize: 0.5,
                destroyDropzone: true,
                addRemoveLinks: true,
            }

        }
    },

    components: {
        vueDropzone: vue2Dropzone,
        VueEditor,
        Datepicker
    },

    validations: {
        TitleDe: {
            required,
            minLength: minLength(3),
            maxLength: maxLength(255)
        },
        TitleFr: {
            required,
            minLength: minLength(3),
            maxLength: maxLength(255)
        },
        PreviewDe: {
            required,
            minLength: minLength(3),
            maxLength: maxLength(255)
        },
        PreviewFr: {
            required,
            minLength: minLength(3),
            maxLength: maxLength(255)
        },
        ContentDe: {
            required        
        },
        ContentFr: {
            required        
        }



    },

    methods: {
        submit () {
            this.$v.$touch();
            if(!this.$v.$invalid){

                const formData = {
                    Date: this.date.toLocaleString(),
                    TitleDe: this.TitleDe,
                    TitleFr: this.TitleFr,
                    ContentDe: this.ContentDe,
                    ContentFr: this.ContentDe,
                    PreviewDe: this.PreviewDe,
                    PreviewFr: this.PreviewFr,
                    UploadImage: this.Image
                }

                let form_data = new FormData()

                for ( var key in formData ) {
                    form_data.append(key, formData[key])
                }

                auth.post('News', form_data)
                .then(response => {
                    console.log(response.data)
                    this.isSubmitted = true;
                }).catch(e => {
                    this.errors.push(e)
                })
            }

      },

      sendingEvent (file, xhr) {
          this.Image = file
          console.log(this.Image)
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
