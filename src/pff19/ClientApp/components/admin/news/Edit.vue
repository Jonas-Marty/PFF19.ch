<template>
                <div>
                    <h2 class="title">News editieren</h2>
                    <div v-if="isSubmitted">
                        <p>Deine News wurde editiert!</p>
                        <router-link
                        :to="{name: 'adminNews'}"
                        >Zurück</router-link>
                    </div>
                   <form @submit.prevent="submit" v-if="!isSubmitted">
                    
                    <div class="form-group dropzone-wrapper" :class="{'invalid-form': $v.Images.$error}">
                        <label for="image_upload">Image upload (Max 3 Bilder, 1 Bild ist Thumpnail)</label>
                        <vue-dropzone
                            ref="myVueDropzone" 
                            id="dropzone" 
                            :options="dropzoneOptions" 
                            v-on:vdropzone-file-added="sendingEvent" 
                            v-on:vdropzone-removed-file="removingFile"
                        >
                            <div class="dropzone-custom-content">
                                <h3 class="dropzone-custom-title">Drag and drop to upload content!</h3>
                                <div class="subtitle">...or click to select a file from your computer</div>
                            </div>    
                        </vue-dropzone> 
                        <div class="error-messages">
                            <p v-if="!$v.Images.required && $v.Images.$dirty">Die News braucht ein Bild</p>
                        </div>  
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
                        <vue-editor class="html-editor" @blur="$v.ContentDe.$touch()" id="contentd_de" :editorToolbar="customToolbar" v-model="ContentDe"></vue-editor>

                        <div class="error-messages"> 
                            <p v-if="!$v.ContentDe.required && $v.ContentDe.$dirty">Es brauch einen Inhalt für deine News</p>
                        </div>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.ContentFr.$error}">
                        <label for="content_fr">Inhalt Französisch</label>
                        <vue-editor class="html-editor" @blur="$v.ContentFr.$touch()" id="contentd_fr" :editorToolbar="customToolbar" v-model="ContentFr"></vue-editor>

                        <div class="error-messages"> 
                            <p v-if="!$v.ContentFr.required && $v.ContentFr.$dirty">Es brauch einen Inhalt für deine News</p>
                        </div>
                    </div>

                    <button type="submit" class="btn btn-primary" >Bestätigen</button>
                </form>

                <div class="help">
                    <h3>Hilfe für News upload</h3>
                    <ul>
                        <li>Bild sollte mindestens 740x555 Auflösung haben</li>
                        <li>Bild sollte 4x3 Format haben</li>
                        <li>Unterstützte Bild Formate sind jpg/png</li>
                        <li>Ich bitte dich die Bilder bereits im richtigen Format hochzuladen 
                            (automatische zuschneiden haben wir noch nicht implementiert)</li>
                        <li>Trage deinen Beitrag zur eine schnelle Webseite und lasse deine 
                            Bilder vor dem Upload komprimieren unter <a href="https://tinyjpg.com/">https://tinyjpg.com/</a> </li>
                        <li>Falls beim Editieren trotzdem noch das alte Bild angezeigt wird, mache einen hard reload im Browser</li>
                    </ul>
                </div>
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
            Images: [],
            date: new Date(),

            customToolbar: [
                ['bold', 'italic', 'underline', 'link'],
                [{ 'list': 'ordered'}, { 'list': 'bullet' }, {'header': ['2','3']}],
            ],

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
        },
        Images: {
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

                auth.put(`News/${this.$route.params.id}`, form_data)
                .then(response => {
                    this.isSubmitted = true;
                }).catch(e => {
                    this.errors.push(e)
                })
            }


      },

      sendingEvent (file) {
            this.Images.push(file)
      },

      updateDate (date) {
          this.date = date;
      },

      removingFile (file) {
        this.Images =  this.Images.filter(image => image.name != file.name)
      },


    },
    
    mounted() {
        auth.get(`News/${this.$route.params.id}`)
            .then(response => {
                this.TitleDe = response.data.titleDe
                this.TitleFr = response.data.titleFr
                this.PreviewDe = response.data.previewDe
                this.PreviewFr = response.data.previewFr
                this.ContentDe = response.data.contentDe
                this.ContentFr = response.data.contentFr
                response.data.images.split(';').forEach(image => {
                    this.$refs.myVueDropzone.manuallyAddFile({ size: 123, name: image, type: "image/jpg" }, `/assets/news/thumbnail/${image}`)
                })

            }).catch(e => {
                this.errors.push(e)
            })
    }

}
</script>

<style lang="scss" scoped>
    .dropzone-wrapper {
        margin-bottom: 50px;
    }

    .title {
        margin-bottom: 20px;
    }

    .html-editor{
        background-color: white;
    }

    .help {
        margin-top: 50px;
    }
</style>
