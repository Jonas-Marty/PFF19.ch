<template>
                <div>
                    <h2 class="title">Band Editiern</h2>

                    <div v-if="isSubmitted">
                        <p>Deine Band wurde upgedated!</p>
                        <router-link :to="{name: 'adminBands'}">
                            Zurück
                        </router-link>
                    </div>

                   <form @submit.prevent="submit" v-if="!isSubmitted">
                    
                    <div class="form-group dropzone-wrapper" :class="{'invalid-form': $v.ImageThumbnail.$error}">
                        <label for="thumpnailUpload">Thumpnail upload (440x330px)</label>
                        <vue-dropzone 
                            ref="thumpnailUpload" 
                            id="thumpnailUpload" 
                            :options="dropzoneOptions" 
                            v-on:vdropzone-file-added="sendingEventThumpnail"
                            v-on:vdropzone-removed-file="removingThumpnail">  
                        </vue-dropzone>   
                        <div class="error-messages">
                            <p v-if="!$v.ImageThumbnail.required && $v.ImageThumbnail.$dirty">Die Band braucht ein Bild</p>
                        </div> 
                    </div>

                    <div class="form-group dropzone-wrapper" :class="{'invalid-form': $v.ImageLarge.$error}">
                        <label for="imageUpload">Image upload (1920x730px)</label>
                        <vue-dropzone 
                            ref="imageUpload" 
                            id="imageUpload" 
                            :options="dropzoneOptions" 
                            v-on:vdropzone-file-added="sendingEventImage"
                            v-on:vdropzone-removed-file="removingImage">
                        </vue-dropzone>   
                        <div class="error-messages">
                            <p v-if="!$v.ImageLarge.required && $v.ImageLarge.$dirty">Die Band braucht ein Bild</p>
                        </div> 
                    </div>

                    <div class="form-group">
                        <label for="select_date">Auftritts Zeit</label>
                        <!-- TODO: Adjust range of time  -->
                        <input 
                            type="datetime-local" 
                            id="meeting-time"
                            value="2019-08-30T19:30"
                            min="2019-08-30T00:00" max="2019-09-01T23:00"
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

                    <div class="form-group" >
                        <label for="youtbe_url">Youtube codes separiert mit comma (Bsp: "Pun1Nxv9f3g, Oun1Nxv9f3a")</label>
                        <input 
                            type="text" 
                            class="form-control" 
                            id="youtbe_url" 
                            placeholder="code1, code2, usw." 
                            v-model="YoutubeUrls"
                        >
                        <div class="error-messages">
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="website_url">Website Url</label>
                        <input 
                            type="text" 
                            class="form-control" 
                            id="website_url" 
                            placeholder="https://www.pff19.ch/" 
                            v-model="WebSiteUrl"
                        >
                        <div class="error-messages">
                        </div>
                    </div>


                    <div class="form-group">
                        <label for="facebook">Facebook Page Url</label>
                        <input 
                            type="text" 
                            class="form-control" 
                            id="facebook" 
                            placeholder="https://www.facebook.com/pff19mosaik/" 
                            v-model="Facebook"
                        >
                        <div class="error-messages">
                        </div>
                    </div>

                    <div class="form-group" >
                        <label for="instagram">Instagram Page Url</label>
                        <input 
                            type="text" 
                            class="form-control" 
                            id="instagram" 
                            placeholder="https://www.instagram.com/pff_19_mosaik/" 
                            v-model="Instagram"
                        >
                        <div class="error-messages">
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="spotify">Spotify Playlist code
                            <a href="https://developer.spotify.com/documentation/widgets/generate/play-button/">hilfe</a>
                        </label>
                        <input 
                            type="text" 
                            class="form-control" 
                            id="spotify" 
                            placeholder="https://open.spotify.com/embed/album/1DFixLWuPkv3KT3TnV35m3" 
                            v-model="SpotifyPlaylist"
                        >
                        <div class="error-messages">
                        </div>
                    </div>

                    <button type="submit" class="btn btn-primary" >Bestätigen</button>
                </form>

                <div class="help">
                    <h3>Hilfe für Band upload</h3>
                    <ul>
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
            Facebook: '',
            YoutubeUrls: '',
            WebSiteUrl: '',
            Instagram: '',
            SpotifyPlaylist: '',
            ImageThumbnail: {},
            ImageLarge: {},

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
        },
        DescriptionFr: {
            required,
            minLength: minLength(3),
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
                    Name: this.Name,
                    PlayTime: this.PlayTime,
                    TitleFr: this.TitleFr,
                    DescriptionDe: this.DescriptionDe,
                    DescriptionFr: this.DescriptionFr,
                    Facebook: this.Facebook,
                    YoutubeUrls: this.YoutubeUrls,
                    Instagram: this.Instagram,
                    SpotifyPlaylist: this.SpotifyPlaylist,
                    WebSiteUrl: this.WebSiteUrl,
                    ImageThumbnail: this.ImageThumbnail,
                    ImageLarge: this.ImageLarge
                }

                let form_data = new FormData()

                for ( var key in formData ) {
                    form_data.append(key, formData[key])
                }

                auth.put(`Bands/${this.$route.params.id}`, form_data)
                .then(response => {
                    this.isSubmitted = true;
                }).catch(e => {
                    this.errors.push(e)
                })
            }

        },

        sendingEventThumpnail (file, xhr) {
            this.ImageThumbnail = file
        },

        sendingEventImage (file, xhr) {
            this.ImageLarge = file
        },

        removingThumpnail (file) {
            this.ImageThumbnail = {}
        },

        removingImage (file) {
            this.ImageLarge = {}
        },
    },

    mounted() {
        auth.get(`Bands/${this.$route.params.id}`)
            .then(response => {
                this.Name = response.data.name
                this.PlayTime = response.data.playTime
                this.DescriptionDe = response.data.descriptionDe
                this.DescriptionFr = response.data.descriptionFr
                this.Facebook = response.data.facebook
                this.YoutubeUrls = response.data.youtubeUrls
                this.Instagram = response.data.instagram
                this.SpotifyPlaylist = response.data.spotifyPlaylist
                this.WebSiteUrl = response.data.webSiteUrl
                this.$refs.thumpnailUpload.manuallyAddFile(
                    { size: 123, name: response.data.imageThumbnail, type: "image/jpg" },
                    `/assets/bands/thumbnail/${response.data.imageThumbnail}`
                )
                this.$refs.imageUpload.manuallyAddFile(
                    { size: 123, name: response.data.imageLarge, type: "image/jpg" },
                    `/assets/bands/images/${response.data.imageLarge}`
                )

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
