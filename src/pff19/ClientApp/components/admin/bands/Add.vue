<template>
  <div>
    <h2 class="title">Band hinzufügen</h2>

    <div v-if="isSubmitted">
      <p>Deine Band wurde hinzugefügt!</p>
      <router-link :to="{ name: 'adminBands' }">Zurück</router-link>
    </div>

    <form v-if="!isSubmitted" @submit.prevent="submit">
      <div
        :class="{ 'invalid-form': $v.ImageThumbnail.$error }"
        class="form-group dropzone-wrapper"
      >
        <label for="thumpnail_upload">Thumpnail upload (440x330px)</label>
        <vue-dropzone
          id="thumpnail_upload"
          ref="thumpnail_upload"
          :options="dropzoneOptions"
          @vdropzone-file-added="sendingEventThumpnail"
          @vdropzone-removed-file="removingThumpnail"
        />
        <div class="error-messages">
          <p
            v-if="!$v.ImageThumbnail.required && $v.ImageThumbnail.$dirty"
          >Die Band braucht ein Bild</p>
        </div>
      </div>

      <div :class="{ 'invalid-form': $v.ImageLarge.$error }" class="form-group dropzone-wrapper">
        <label for="image_upload">Image upload (1920x730px)</label>
        <vue-dropzone
          id="image_upload"
          ref="image_upload"
          :options="dropzoneOptions"
          @vdropzone-file-added="sendingEventImage"
          @vdropzone-removed-file="removingImage"
        />
        <div class="error-messages">
          <p v-if="!$v.ImageLarge.required && $v.ImageLarge.$dirty">Die Band braucht ein Bild</p>
        </div>
      </div>

      <div class="form-group dropzone-wrapper">
        <label for="smartphone_image_upload">Smartphone Image upload (768x400)</label>
        <vue-dropzone
          id="smartphone_image_upload"
          ref="smartphone_image_upload"
          :options="dropzoneOptions"
          @vdropzone-file-added="sendingEventMobileImage"
          @vdropzone-removed-file="removingMobileImage"
        />
      </div>

      <div class="form-group">
        <label for="timeForSorting">
          Aufrittszeit (für die Sortierung und Gruppierung nach Tag in der TimeTable verwendet,
          MM-dd-YYYY HH-mm)
        </label>
        <input id="time" v-model="PlayTimeForSorting" type="datetime-local" class="form-control" />
        <div class="error-messages" />
      </div>

      <div :class="{ 'invalid-form': $v.Name.$error }" class="form-group">
        <label for="name">Name</label>
        <input
          id="name"
          v-model="Name"
          @blur="$v.Name.$touch()"
          type="text"
          class="form-control"
          placeholder="Name der Band"
        />
        <div class="error-messages">
          <p v-if="!$v.Name.required && $v.Name.$dirty">Bitte ein Name eingeben</p>
        </div>
      </div>

      <div :class="{ 'invalid-form': $v.DescriptionDe.$error }" class="form-group">
        <label for="description_de">Description Deutsch</label>
        <vue-editor
          id="description_de"
          v-model="DescriptionDe"
          :editor-options="optionsEditor"
          :editor-toolbar="customToolbar"
          @blur="$v.DescriptionDe.$touch()"
          class="html-editor"
        />

        <div class="error-messages">
          <p
            v-if="!$v.DescriptionDe.required && $v.DescriptionDe.$dirty"
          >Es braucht eine Bescpreibung zur Band</p>
          <p
            v-if="!$v.DescriptionDe.minLength && $v.DescriptionDe.$dirty"
          >Deine Beschreibung ist zu kurz</p>
        </div>
      </div>

      <div :class="{ 'invalid-form': $v.DescriptionFr.$error }" class="form-group">
        <label for="description_fr">Description Französisch</label>
        <vue-editor
          id="description_fr"
          v-model="DescriptionFr"
          :editor-options="optionsEditor"
          :editor-toolbar="customToolbar"
          @blur="$v.DescriptionFr.$touch()"
          class="html-editor"
        />

        <div class="error-messages">
          <p
            v-if="!$v.DescriptionFr.required && $v.DescriptionFr.$dirty"
          >Es braucht eine Bescpreibung zur Band</p>
          <p
            v-if="!$v.DescriptionFr.minLength && $v.DescriptionFr.$dirty"
          >Deine Beschreibung ist zu kurz</p>
        </div>
      </div>

      <div class="form-group">
        <label for="stage">Bühne (optional)</label>
        <input id="stage" v-model="Stage" type="text" class="form-control" placeholder="stage" />
        <div class="error-messages" />
      </div>

      <div class="form-group">
        <label for="youtbe_url">Youtube codes separiert mit comma (Bsp: "Pun1Nxv9f3g, Oun1Nxv9f3a")</label>
        <input
          id="youtbe_url"
          v-model="YoutubeUrls"
          type="text"
          class="form-control"
          placeholder="code1, code2, usw."
        />
        <div class="error-messages" />
      </div>

      <div class="form-group">
        <label for="website_url">Website Url</label>
        <input
          id="website_url"
          v-model="WebSiteUrl"
          type="text"
          class="form-control"
          placeholder="https://www.pff19.ch/"
        />
        <div class="error-messages" />
      </div>

      <div class="form-group">
        <label for="facebook">Facebook Page Url</label>
        <input
          id="facebook"
          v-model="Facebook"
          type="text"
          class="form-control"
          placeholder="https://www.facebook.com/pff19mosaik/"
        />
        <div class="error-messages" />
      </div>

      <div class="form-group">
        <label for="instagram">Instagram Page Url</label>
        <input
          id="instagram"
          v-model="Instagram"
          type="text"
          class="form-control"
          placeholder="https://www.instagram.com/pff_19_mosaik/"
        />
        <div class="error-messages" />
      </div>

      <div class="form-group">
        <label for="spotify">
          Spotify Playlist code
          <a
            href="https://developer.spotify.com/documentation/widgets/generate/play-button/"
          >hilfe</a>
        </label>
        <input
          id="spotify"
          v-model="SpotifyPlaylist"
          type="text"
          class="form-control"
          placeholder="https://open.spotify.com/embed/album/1DFixLWuPkv3KT3TnV35m3"
        />
        <div class="error-messages" />
      </div>

      <button type="submit" class="btn btn-primary">Bestätigen</button>
    </form>

    <div class="help">
      <h3>Hilfe für Bands upload</h3>
      <ul>
        <li>Unterstützte Bild Formate sind jpg/png</li>
        <li>
          Ich bitte dich die Bilder bereits im richtigen Format hochzuladen (automatische
          zuschneiden haben wir noch nicht implementiert)
        </li>
        <li>
          Trage deinen Beitrag zur eine schnelle Webseite und lasse deine Bilder vor dem Upload
          komprimieren unter
          <a
            href="https://tinyjpg.com/"
          >https://tinyjpg.com/</a>
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
      PlayTimeForSorting: '',
      Name: '',
      DescriptionDe: '',
      DescriptionFr: '',
      Facebook: '',
      YoutubeUrls: '',
      WebSiteUrl: '',
      Instagram: '',
      Stage: '',
      SpotifyPlaylist: '',
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

  validations: {
    Name: {
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
          Name: this.Name,
          PlayTime: this.PlayTime,
          TitleFr: this.TitleFr,
          DescriptionDe: this.DescriptionDe,
          DescriptionFr: this.DescriptionFr,
          Facebook: this.Facebook,
          YoutubeUrls: this.YoutubeUrls,
          Instagram: this.Instagram,
          WebSiteUrl: this.WebSiteUrl,
          SpotifyPlaylist: this.SpotifyPlaylist,
          ImageThumbnail: this.ImageThumbnail,
          ImageLarge: this.ImageLarge,
          ImageMobile: this.ImageMobile,
          Stage: this.Stage,
          PlayTimeForSorting: this.PlayTimeForSorting
        }

        let form_data = new FormData()

        for (var key in formData) {
          form_data.append(key, formData[key])
        }

        auth
          .post('Bands', form_data)
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
