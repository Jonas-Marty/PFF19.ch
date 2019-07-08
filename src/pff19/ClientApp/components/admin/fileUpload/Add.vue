<template>
  <div>
    <h2 class="title">
      File Uploaden
    </h2>

    <div v-if="isSubmitted">
      <p>Dein File wurde hinzugefügt!</p>
      <router-link :to="{ name: 'adminFileUpload' }">
        Zurück
      </router-link>
    </div>

    <form v-if="!isSubmitted" @submit.prevent="submit">
      <div :class="{ 'invalid-form': $v.File.$error }" class="form-group dropzone-wrapper">
        <label for="file_upload">File upload</label>
        <vue-dropzone
          id="file_upload"
          ref="file_upload"
          :options="dropzoneOptions"
          @vdropzone-file-added="sendingEventFile"
          @vdropzone-removed-file="removingFile"
        />
        <div class="error-messages">
          <p v-if="!$v.File.required && $v.File.$dirty">
            Es muss ein File upgeloaded werden
          </p>
        </div>
      </div>
      <button type="submit" class="btn btn-primary">
        Bestätigen
      </button>
    </form>
  </div>
</template>

<script>
import auth from 'utils/auth'
import vue2Dropzone from 'vue2-dropzone'
import 'vue2-dropzone/dist/vue2Dropzone.min.css'
import { required } from 'vuelidate/lib/validators'

export default {
  components: {
    vueDropzone: vue2Dropzone
  },
  data() {
    return {
      errors: [],
      isSubmitted: false,
      File: {},

      dropzoneOptions: {
        url: '/api',
        autoProcessQueue: false,
        thumbnailWidth: 150,
        maxFilesize: 3.5,
        maxFiles: 1,
        destroyDropzone: true,
        addRemoveLinks: true
      }
    }
  },

  validations: {
    File: {
      required
    }
  },

  methods: {
    submit() {
      this.$v.$touch()
      if (!this.$v.$invalid) {
        const formData = {
          File: this.File
        }

        let form_data = new FormData()

        for (var key in formData) {
          form_data.append(key, formData[key])
        }

        auth
          .post('file', form_data)
          .then(() => {
            this.isSubmitted = true
          })
          .catch(e => {
            this.errors.push(e)
          })
      }
    },

    sendingEventFile(file) {
      this.File = file
    },

    removingFile() {
      this.File = {}
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
