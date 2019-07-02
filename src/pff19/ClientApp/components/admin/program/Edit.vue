<template>
  <div>
    <h2 class="title">Programmpunkt Editiern</h2>

    <div v-if="isSubmitted">
      <p>Deine Programmpunkt wurde upgedated!</p>
      <router-link :to="{ name: 'adminProgram' }">Zurück</router-link>
    </div>

    <form @submit.prevent="submit" v-if="!isSubmitted">
      <div
        :class="{ 'invalid-form': $v.ImageThumbnail.$error }"
        class="form-group dropzone-wrapper"
      >
        <label for="thumpnailUpload">Thumpnail upload (440x330px)</label>
        <vue-dropzone
          id="thumpnailUpload"
          ref="thumpnailUpload"
          :options="dropzoneOptions"
          v-on:vdropzone-file-added="sendingEventThumpnail"
          v-on:vdropzone-removed-file="removingThumpnail"
        ></vue-dropzone>
        <div class="error-messages">
          <p v-if="!$v.ImageThumbnail.required && $v.ImageThumbnail.$dirty">
            Es braucht ein Thumbnail Bild
          </p>
        </div>
      </div>

      <div :class="{ 'invalid-form': $v.ImageLarge.$error }" class="form-group dropzone-wrapper">
        <label for="imageUpload">Image upload (1920x730px)</label>
        <vue-dropzone
          id="imageUpload"
          ref="imageUpload"
          :options="dropzoneOptions"
          v-on:vdropzone-file-added="sendingEventImage"
          v-on:vdropzone-removed-file="removingImage"
        ></vue-dropzone>
        <div class="error-messages">
          <p v-if="!$v.ImageLarge.required && $v.ImageLarge.$dirty">
            Es braucht ein big Screen Bild
          </p>
        </div>
      </div>

      <div class="form-group dropzone-wrapper">
        <label for="mobileUpload">Smartphone Image upload (768x400)</label>
        <vue-dropzone
          id="mobileUpload"
          ref="mobileUpload"
          :options="dropzoneOptions"
          v-on:vdropzone-file-added="sendingEventMobileImage"
          v-on:vdropzone-removed-file="removingMobileImage"
        ></vue-dropzone>
      </div>

      <div class="form-group">
        <label for="timeForSorting">
          Durchführ Startzeit (optional, Format: MM-dd-YYYY HH-mm)
        </label>
        <input id="time" v-model="StartTime" type="datetime-local" class="form-control" />
      </div>

      <div :class="{ 'invalid-form': $v.NameDe.$error }" class="form-group">
        <label for="name_de">NameDe</label>
        <input
          id="name_de"
          @blur="$v.NameDe.$touch()"
          v-model="NameDe"
          type="text"
          class="form-control"
          placeholder="Name Deutsch"
        />
        <div class="error-messages">
          <p v-if="!$v.NameDe.required && $v.NameDe.$dirty">Bitte ein Name eingeben</p>
        </div>
      </div>

      <div :class="{ 'invalid-form': $v.NameFr.$error }" class="form-group">
        <label for="name_fr">NameFr</label>
        <input
          id="name_fr"
          @blur="$v.NameFr.$touch()"
          v-model="NameFr"
          type="text"
          class="form-control"
          placeholder="Name Französisch"
        />
        <div class="error-messages">
          <p v-if="!$v.NameFr.required && $v.NameFr.$dirty">Bitte ein Name eingeben</p>
        </div>
      </div>

      <div :class="{ 'invalid-form': $v.DescriptionDe.$error }" class="form-group">
        <label for="description_de">Description Deutsch</label>
        <vue-editor
          id="description_de"
          @blur="$v.DescriptionDe.$touch()"
          :editorOptions="optionsEditor"
          :editorToolbar="customToolbar"
          v-model="DescriptionDe"
          class="html-editor"
        ></vue-editor>

        <div class="error-messages">
          <p v-if="!$v.DescriptionDe.required && $v.DescriptionDe.$dirty">
            Es braucht eine Bescpreibung
          </p>
          <p v-if="!$v.DescriptionDe.minLength && $v.DescriptionDe.$dirty">
            Deine Beschreibung ist zu kurz
          </p>
        </div>
      </div>

      <div :class="{ 'invalid-form': $v.DescriptionFr.$error }" class="form-group">
        <label for="description_fr">Description Französisch</label>
        <vue-editor
          id="description_fr"
          @blur="$v.DescriptionFr.$touch()"
          :editorOptions="optionsEditor"
          :editorToolbar="customToolbar"
          v-model="DescriptionFr"
          class="html-editor"
        ></vue-editor>

        <div class="error-messages">
          <p v-if="!$v.DescriptionFr.required && $v.DescriptionFr.$dirty">
            Es braucht eine Bescpreibung
          </p>
          <p v-if="!$v.DescriptionFr.minLength && $v.DescriptionFr.$dirty">
            Deine Beschreibung ist zu kurz
          </p>
        </div>
      </div>

      <button type="submit" class="btn btn-primary">Bestätigen</button>
    </form>

    <div class="help">
      <h3>Hilfe für Programmpunkt upload</h3>
      <ul>
        <li>Unterstützte Bild Formate sind jpg/png</li>
        <li>
          Ich bitte dich die Bilder bereits im richtigen Format hochzuladen (automatische
          zuschneiden haben wir noch nicht implementiert)
        </li>
        <li>
          Trage deinen Beitrag zur eine schnelle Webseite und lasse deine Bilder vor dem Upload
          komprimieren unter
          <a href="https://tinyjpg.com/">https://tinyjpg.com/</a>
        </li>
        <li>
          Falls beim Editieren trotzdem noch das alte Bild angezeigt wird, mache einen hard reload
          im Browser
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
import auth from 'utils/auth'
import { convertToFormData } from 'utils/helpers'
import vue2Dropzone from 'vue2-dropzone'
import { VueEditor } from 'vue2-editor'
import 'vue2-dropzone/dist/vue2Dropzone.min.css'
import { required, maxLength, minLength } from 'vuelidate/lib/validators'

export default {
  components: {
    vueDropzone: vue2Dropzone,
    VueEditor
  },
  data() {
    return {
      errors: [],
      isSubmitted: false,
      NameDe: '',
      NameFr: '',
      StartTime: '',
      DescriptionDe: '',
      DescriptionFr: '',
      ImageThumbnail: {},
      ImageLarge: {},
      ImageMobile: {},
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

  mounted() {
    auth
      .get(`socialprograms/${this.$route.params.id}`)
      .then(response => {
        this.NameDe = response.data.nameDe
        this.NameFr = response.data.nameFr
        this.StartTime = response.data.startTime ? response.data.startTime : ''
        this.DescriptionDe = response.data.descriptionDe
        this.DescriptionFr = response.data.descriptionFr
        this.$refs.thumpnailUpload.manuallyAddFile(
          { size: 123, name: response.data.imageThumbnail, type: 'image/jpg' },
          `/assets/socialPrograms/thumbnail/${response.data.imageThumbnail}`
        )
        this.$refs.imageUpload.manuallyAddFile(
          { size: 123, name: response.data.imageLarge, type: 'image/jpg' },
          `/assets/socialPrograms/images/${response.data.imageLarge}`
        )
        this.$refs.mobileUpload.manuallyAddFile(
          { size: 123, name: response.data.imageMobile, type: 'image/jpg' },
          `/assets/socialPrograms/mobile/${response.data.imageMobile}`
        )
      })
      .catch(e => {
        this.errors.push(e)
      })
  },

  methods: {
    submit() {
      this.$v.$touch()
      if (!this.$v.$invalid) {
        const formData = {
          NameDe: this.NameDe,
          NameFr: this.NameFr,
          StartTime: this.StartTime,
          DescriptionDe: this.DescriptionDe,
          DescriptionFr: this.DescriptionFr,
          ImageThumbnail: this.ImageThumbnail,
          ImageLarge: this.ImageLarge,
          ImageMobile: this.ImageMobile
        }

        auth
          .put(`socialprograms/${this.$route.params.id}`, convertToFormData(formData))
          .then(() => {
            this.isSubmitted = true
          })
          .catch(e => {
            this.errors.push(e)
          })
      }
    },

    sendingEventThumpnail(file) {
      this.ImageThumbnail = file
    },

    sendingEventImage(file) {
      this.ImageLarge = file
    },

    sendingEventMobileImage(file) {
      this.ImageMobile = file
    },

    removingThumpnail() {
      this.ImageThumbnail = {}
    },

    removingImage() {
      this.ImageLarge = {}
    },

    removingMobileImage() {
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
