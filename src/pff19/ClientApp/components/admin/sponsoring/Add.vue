<template>
  <div>
    <h2 class="title">Sponsor hinzufügen</h2>
    <div v-if="isSubmitted">
      <p>Ein neuer Sponsor wurde hinzugefügt!</p>
      <router-link :to="{ name: 'adminSponsoring' }">Zurück</router-link>
    </div>
    <form @submit.prevent="submit" v-if="!isSubmitted">
      <div class="form-group">
        <label for="dropzone">Logo upload (für Gönner braucht es kein Bild) 400x150px</label>
        <vue-dropzone
          id="dropzone"
          ref="myVueDropzone"
          :options="dropzoneOptions"
          v-on:vdropzone-file-added="sendingEvent"
        >
          <div class="dropzone-custom-content">
            <h3 class="dropzone-custom-title">Drag and drop to upload content!</h3>
            <div class="subtitle">...or click to select a file from your computer</div>
          </div>
        </vue-dropzone>
      </div>

      <div :class="{ 'invalid-form': $v.name.$error }" class="form-group">
        <label for="name">Name*</label>
        <input
          id="name"
          @blur="$v.name.$touch()"
          v-model="name"
          type="text"
          class="form-control"
          placeholder="Name der Firma"
        />
        <div class="error-messages">
          <p v-if="!$v.name.required && $v.name.$dirty">Bitte einen Namen eingeben</p>
          <p v-if="!$v.name.minLength && $v.name.$dirty">Dein Name ist zu kurz</p>
          <p v-if="!$v.name.maxLength && $v.name.$dirty">Dein Name ist zu lang</p>
        </div>
      </div>

      <div :class="{ 'invalid-form': $v.link.$error }" class="form-group">
        <label for="link">Link zur Firma Webseite</label>
        <input
          id="link"
          @blur="$v.link.$touch()"
          v-model="link"
          type="text"
          class="form-control"
          placeholder="Der Link zur Firma"
        />
        <div class="error-messages">
          <p v-if="!$v.link.minLength && $v.link.$dirty">Dein Link ist zu kurz</p>
        </div>
      </div>

      <div class="form-group">
        <label for="typ_of_sponsor">Sponsor Typ*</label>
        <select id="typ_of_sponsor" @blur="$v.link.$touch()" v-model="typ" class="form-control">
          <option value="6">Gönner (Unternehmen)</option>
          <option value="5">Pfadi-Partner</option>
          <option value="4">Infrastruktur Partner</option>
          <option value="3">Gönner (Privatperson)</option>
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
import auth from 'utils/auth'
import vue2Dropzone from 'vue2-dropzone'
import 'vue2-dropzone/dist/vue2Dropzone.min.css'
import { required, maxLength, minLength } from 'vuelidate/lib/validators'

export default {
  components: {
    vueDropzone: vue2Dropzone
  },
  data() {
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
        addRemoveLinks: true
      }
    }
  },

  validations: {
    name: {
      required,
      minLength: minLength(3),
      maxLength: maxLength(255)
    },
    link: {
      minLength: minLength(3)
    },
    typ: {
      required
    }
  },

  methods: {
    submit() {
      this.$v.$touch()
      if (!this.$v.$invalid) {
        const formData = {
          Name: this.name,
          Link: this.link,
          Status: this.typ,
          UploadImage: this.Logo
        }

        let form_data = new FormData()

        for (var key in formData) {
          form_data.append(key, formData[key])
        }

        auth
          .post('Sponsors', form_data)
          .then(() => {
            this.isSubmitted = true
          })
          .catch(e => {
            this.errors.push(e)
          })
      }
    },

    sendingEvent(file) {
      this.Logo = file
    },

    updateDate(date) {
      this.date = date
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

.html-editor {
  background-color: white;
}
</style>
