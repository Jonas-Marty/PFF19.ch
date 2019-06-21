<template>
    <div>
        <h2 class="title">Food oder Bar hinzufügen</h2>

        <div v-if="isSubmitted">
            <p>Deine Bar wurde hinzugefügt!</p>
            <router-link :to="{ name: 'adminFoodAndBars' }">
                Zurück
            </router-link>
        </div>

        <form @submit.prevent="submit" v-if="!isSubmitted">
            <div
                class="form-group dropzone-wrapper"
                :class="{ 'invalid-form': $v.ImageThumbnail.$error }"
            >
                <label for="thumpnail_upload">Thumpnail upload (440x330px)</label>
                <vue-dropzone
                    ref="thumpnail_upload"
                    id="thumpnail_upload"
                    :options="dropzoneOptions"
                    v-on:vdropzone-file-added="sendingEventThumpnail"
                    v-on:vdropzone-removed-file="removingThumpnail"
                >
                </vue-dropzone>
                <div class="error-messages">
                    <p v-if="!$v.ImageThumbnail.required && $v.ImageThumbnail.$dirty">
                        Es braucht ein Thumbnail Bild
                    </p>
                </div>
            </div>

            <div
                class="form-group dropzone-wrapper"
                :class="{ 'invalid-form': $v.ImageLarge.$error }"
            >
                <label for="image_upload">Image upload (1920x730px)</label>
                <vue-dropzone
                    ref="image_upload"
                    id="image_upload"
                    :options="dropzoneOptions"
                    v-on:vdropzone-file-added="sendingEventImage"
                    v-on:vdropzone-removed-file="removingImage"
                >
                </vue-dropzone>
                <div class="error-messages">
                    <p v-if="!$v.ImageLarge.required && $v.ImageLarge.$dirty">
                        Es braucht ein big Screen Bild
                    </p>
                </div>
            </div>

            <div class="form-group dropzone-wrapper">
                <label for="smartphone_image_upload">Smartphone Image upload (768x400)</label>
                <vue-dropzone
                    ref="smartphone_image_upload"
                    id="smartphone_image_upload"
                    :options="dropzoneOptions"
                    v-on:vdropzone-file-added="sendingEventMobileImage"
                    v-on:vdropzone-removed-file="removingMobileImage"
                >
                </vue-dropzone>
            </div>

            <div class="form-group" :class="{ 'invalid-form': $v.NameDe.$error }">
                <label for="name_de">NameDe</label>
                <input
                    type="text"
                    @blur="$v.NameDe.$touch()"
                    class="form-control"
                    id="name_de"
                    placeholder="Name Deutsch"
                    v-model="NameDe"
                />
                <div class="error-messages">
                    <p v-if="!$v.NameDe.required && $v.NameDe.$dirty">Bitte ein Name eingeben</p>
                </div>
            </div>

            <div class="form-group" :class="{ 'invalid-form': $v.NameFr.$error }">
                <label for="name_fr">NameFr</label>
                <input
                    type="text"
                    @blur="$v.NameFr.$touch()"
                    class="form-control"
                    id="name_fr"
                    placeholder="Name Französisch"
                    v-model="NameFr"
                />
                <div class="error-messages">
                    <p v-if="!$v.NameFr.required && $v.NameFr.$dirty">Bitte ein Name eingeben</p>
                </div>
            </div>

            <div class="form-group" :class="{ 'invalid-form': $v.DescriptionDe.$error }">
                <label for="description_de">Description Deutsch</label>
                <vue-editor
                    class="html-editor"
                    @blur="$v.DescriptionDe.$touch()"
                    id="description_de"
                    :editorOptions="optionsEditor"
                    :editorToolbar="customToolbar"
                    v-model="DescriptionDe"
                ></vue-editor>

                <div class="error-messages">
                    <p v-if="!$v.DescriptionDe.required && $v.DescriptionDe.$dirty">
                        Es braucht eine Bescpreibung zur Band
                    </p>
                    <p v-if="!$v.DescriptionDe.minLength && $v.DescriptionDe.$dirty">
                        Deine Beschreibung ist zu kurz
                    </p>
                </div>
            </div>

            <div class="form-group" :class="{ 'invalid-form': $v.DescriptionFr.$error }">
                <label for="description_fr">Description Französisch</label>
                <vue-editor
                    class="html-editor"
                    @blur="$v.DescriptionFr.$touch()"
                    id="description_fr"
                    :editorOptions="optionsEditor"
                    :editorToolbar="customToolbar"
                    v-model="DescriptionFr"
                ></vue-editor>

                <div class="error-messages">
                    <p v-if="!$v.DescriptionFr.required && $v.DescriptionFr.$dirty">
                        Es braucht eine Bescpreibung zur Band
                    </p>
                    <p v-if="!$v.DescriptionFr.minLength && $v.DescriptionFr.$dirty">
                        Deine Beschreibung ist zu kurz
                    </p>
                </div>
            </div>

            <button type="submit" class="btn btn-primary">Bestätigen</button>
        </form>

        <div class="help">
            <h3>Hilfe für Bar upload</h3>
            <ul>
                <li>Unterstützte Bild Formate sind jpg/png</li>
                <li>
                    Ich bitte dich die Bilder bereits im richtigen Format hochzuladen (automatische
                    zuschneiden haben wir noch nicht implementiert)
                </li>
                <li>
                    Trage deinen Beitrag zur eine schnelle Webseite und lasse deine Bilder vor dem
                    Upload komprimieren unter
                    <a href="https://tinyjpg.com/">https://tinyjpg.com/</a>
                </li>
                <li>
                    Falls beim Editieren trotzdem noch das alte Bild angezeigt wird, mache einen
                    hard reload im Browser
                </li>
            </ul>
        </div>
    </div>
</template>

<script>
import auth from '../../../auth.js'
import { convertToFormData } from '../../../helpers.js'
import vue2Dropzone from 'vue2-dropzone'
import { VueEditor } from 'vue2-editor'
import Datepicker from 'vuejs-datepicker'
import 'vue2-dropzone/dist/vue2Dropzone.min.css'
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
    data() {
        return {
            errors: [],
            isSubmitted: false,
            NameDe: '',
            NameFr: '',
            DescriptionDe: '',
            DescriptionFr: '',
            ImageThumbnail: {},
            ImageLarge: {},
            optionsEditor: {
                formats: ['bold', 'underline', 'italic', 'list', 'link', 'header']
            },
            customToolbar: [
                ['bold', 'italic', 'underline', 'link'],
                [{ list: 'ordered' }, { list: 'bullet' }, { header: ['2', '3'] }]
            ],

            dropzoneOptions: {
                url: '/api',
                autoProcessQueue: false,
                thumbnailWidth: 150,
                maxFilesize: 1.5,
                maxFiles: 1,
                destroyDropzone: true,
                addRemoveLinks: true
            }
        }
    },

    components: {
        vueDropzone: vue2Dropzone,
        VueEditor
    },

    validations: {
        NameDe: {
            required,
            minLength: minLength(3),
            maxLength: maxLength(255)
        },
        NameFr: {
            required,
            minLength: minLength(3),
            maxLength: maxLength(255)
        },
        DescriptionDe: {
            required,
            minLength: minLength(3)
        },
        DescriptionFr: {
            required,
            minLength: minLength(3)
        },
        ImageThumbnail: {
            required
        },
        ImageLarge: {
            required
        }
    },

    methods: {
        submit() {
            this.$v.$touch()
            if (!this.$v.$invalid) {
                const formData = {
                    NameDe: this.NameDe,
                    NameFr: this.NameFr,
                    DescriptionDe: this.DescriptionDe,
                    DescriptionFr: this.DescriptionFr,
                    ImageThumbnail: this.ImageThumbnail,
                    ImageLarge: this.ImageLarge,
                    ImageMobile: this.ImageMobile,
                }

                let form_data = new FormData()

                for (var key in formData) {
                    form_data.append(key, formData[key])
                }

                auth.post('bars', form_data)
                    .then(response => {
                        this.isSubmitted = true
                    })
                    .catch(e => {
                        this.errors.push(e)
                    })
            }
        },

        sendingEventThumpnail(file, xhr) {
            this.ImageThumbnail = file
        },

        sendingEventImage(file, xhr) {
            this.ImageLarge = file
        },

        sendingEventMobileImage(file, xhr) {
            this.ImageMobile = file
        },

        removingThumpnail(file) {
            this.ImageThumbnail = {}
        },

        removingImage(file) {
            this.ImageLarge = {}
        },
        removingMobileImage(file) {
            this.ImageMobile = {}
        }
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

.html-editor {
    background-color: white;
}

.help {
    margin-top: 50px;
}
</style>
