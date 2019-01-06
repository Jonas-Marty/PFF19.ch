<template>
                <div>
                    <h2 class="title">Band hinzufügen</h2>
                    <div v-if="isSubmitted">
                        <p>Deine News wurde hinzugefügt!</p>
                        <router-link
                        :to="{name: 'adminNews'}"
                        >Zurück</router-link>
                    </div>
                   <form @submit.prevent="submit" v-if="!isSubmitted">
                    
                    <div class="form-group">
                        <label for="thumpnail">Thumpnail upload (440x330px)</label>
                        <vue-dropzone ref="myVueDropzone" id="dropzone" :options="dropzoneOptions" v-on:vdropzone-file-added="sendingEvent">
                            <div class="dropzone-custom-content">
                                <h3 class="dropzone-custom-title">Drag and drop to upload content!</h3>
                                <div class="subtitle">...or click to select a file from your computer</div>
                            </div>    
                        </vue-dropzone>   
                    </div>

                    <div class="form-group">
                        <label for="title_de">Image upload (1920x730px)</label>
                        <vue-dropzone ref="myVueDropzone" id="dropzone" :options="dropzoneOptions" v-on:vdropzone-file-added="sendingEvent">
                            <div class="dropzone-custom-content">
                                <h3 class="dropzone-custom-title">Drag and drop to upload content!</h3>
                                <div class="subtitle">...or click to select a file from your computer</div>
                            </div>    
                        </vue-dropzone>   
                    </div>

                    <div class="form-group">
                        <label for="select_date">Auftritts Zeit</label>
                        <!-- TODO: Adjust range of time  -->
                        <input 
                            type="datetime-local" 
                            @blur="$v.PlayTime.$touch()" 
                            id="meeting-time"
                            value="2019-08-30T19:30"
                            min="2019-08-30T00:00" max="2018-09-01T23:00"
                            class="form-control"
                            v-model="PlayTime"
                            >
                        <div class="error-messages">
                        </div>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.Name.$error}">
                        <label for="name">Name</label>
                        <input 
                            type="text" 
                            @blur="$v.Name.$touch()" 
                            class="form-control" 
                            id="name" 
                            placeholder="Name der Band" 
                            v-model="Name"
                        >
                        <div class="error-messages">
                            <p v-if="!$v.Name.required && $v.Name.$dirty">Bitte ein Name eingeben</p>
                        </div>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.DescriptionDe.$error}">
                        <label for="description_de">Description Deutsch</label>
                        <vue-editor class="html-editor" @blur="$v.DescriptionDe.$touch()" id="description_de" :editorToolbar="customToolbar" v-model="DescriptionDe"></vue-editor>

                        <div class="error-messages"> 
                            <p v-if="!$v.DescriptionDe.required && $v.DescriptionDe.$dirty">Es braucht eine Bescpreibung zur Band</p>
                            <p v-if="!$v.DescriptionDe.minLength && $v.DescriptionDe.$dirty">Deine Beschreibung ist zu kurz</p>
                        </div>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.DescriptionFr.$error}">
                        <label for="description_fr">Description Französisch</label>
                        <vue-editor class="html-editor" @blur="$v.DescriptionFr.$touch()" id="description_fr" :editorToolbar="customToolbar" v-model="DescriptionFr"></vue-editor>

                        <div class="error-messages"> 
                            <p v-if="!$v.DescriptionFr.required && $v.DescriptionFr.$dirty">Es braucht eine Bescpreibung zur Band</p>
                            <p v-if="!$v.DescriptionFr.minLength && $v.DescriptionFr.$dirty">Deine Beschreibung ist zu kurz</p>
                        </div>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.YoutubeUrls.$error}">
                        <label for="youtbe_url">Youtube codes separiert mit comma (Bsp: "Pun1Nxv9f3g, Oun1Nxv9f3a")</label>
                        <input 
                            type="text" 
                            @blur="$v.YoutubeUrls.$touch()" 
                            class="form-control" 
                            id="youtbe_url" 
                            placeholder="code1, code2, usw." 
                            v-model="YoutubeUrls"
                        >
                        <div class="error-messages">
                        </div>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.WebSiteUrl.$error}">
                        <label for="website_url">Website Url</label>
                        <input 
                            type="text" 
                            @blur="$v.WebSiteUrl.$touch()" 
                            class="form-control" 
                            id="website_url" 
                            placeholder="https://www.pff19.ch/" 
                            v-model="WebSiteUrl"
                        >
                        <div class="error-messages">
                        </div>
                    </div>


                    <div class="form-group" :class="{'invalid-form': $v.Facebook.$error}">
                        <label for="facebook">Facebook Page Url</label>
                        <input 
                            type="text" 
                            @blur="$v.Facebook.$touch()" 
                            class="form-control" 
                            id="facebook" 
                            placeholder="https://www.facebook.com/pff19mosaik/" 
                            v-model="Facebook"
                        >
                        <div class="error-messages">
                        </div>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.Instagram.$error}">
                        <label for="instagram">Instagram Page Url</label>
                        <input 
                            type="text" 
                            @blur="$v.Instagram.$touch()" 
                            class="form-control" 
                            id="instagram" 
                            placeholder="https://www.instagram.com/pff_19_mosaik/" 
                            v-model="Instagram"
                        >
                        <div class="error-messages">
                        </div>
                    </div>

                    <button type="submit" class="btn btn-primary" >Bestätigen</button>
                </form>
            </div>

</template>

<script>
import auth from '../../../auth.js'
import {convertToFormData} from '../../../helpers.js'
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
            PlayTime: '',
            Name: '',
            DescriptionDe: '',
            DescriptionFr: '',
            YoutubeUrls: '',
            WebSiteUrl: '',
            Instagram: '',
            ImageThumbnail: [],
            ImageLarge: [],

            customToolbar: [
                ['bold', 'italic', 'underline', 'link'],
                [{ 'list': 'ordered'}, { 'list': 'bullet' }, {'header': ['2','3']}],
            ],

            dropzoneOptions: {
                url: '/api',
                autoProcessQueue: false,
                thumbnailWidth: 150,
                maxFilesize: 0.5,
                maxFiles: 3,
                destroyDropzone: true,
                addRemoveLinks: true,
            }

        }
    },

    components: {
        vueDropzone: vue2Dropzone,
        VueEditor,
    },

    validations: {
        Name: {
            required,
            minLength: minLength(3),
            maxLength: maxLength(255)
        },
        DescriptionDe: {
            required,
            minLength: minLength(3),
            maxLength: maxLength(255)
        },
        DescriptionFr: {
            required,
            minLength: minLength(3),
            maxLength: maxLength(255)
        },
        ImageThumbnail: {
            required        
        },
        ImageLarge: {
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
                    ContentFr: this.ContentFr,
                    PreviewDe: this.PreviewDe,
                    PreviewFr: this.PreviewFr,
                }

                let form_data = new FormData()

                for ( var key in formData ) {
                    form_data.append(key, formData[key])
                }

                this.Images.forEach(image => {
                    form_data.append("images", image)
                })

                auth.post('News', form_data)
                .then(response => {
                    this.isSubmitted = true;
                }).catch(e => {
                    this.errors.push(e)
                })
            }

      },

      sendingEvent (file, xhr) {
            this.Images.push(file)
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
