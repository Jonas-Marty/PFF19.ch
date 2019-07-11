<template>
  <div>
    <h2 class="title">FAQ editieren</h2>
    <div v-if="isSubmitted">
      <p>Die FAQ wurde geändert!</p>
      <router-link :to="{ name: 'adminFAQs' }">Zurück</router-link>
    </div>
    <form v-if="!isSubmitted" @submit.prevent="submit">
      <div :class="{ 'invalid-form': $v.QuestionDe.$error }" class="form-group">
        <label for="question_de">Frage in Deutsch</label>
        <input
          id="question_de"
          v-model="QuestionDe"
          @blur="$v.QuestionDe.$touch()"
          type="text"
          class="form-control"
          placeholder="Deine Frage in Deutsch"
        />
        <div class="error-messages">
          <p v-if="!$v.QuestionDe.required && $v.QuestionDe.$dirty">Bitte eine Frage eingeben</p>
        </div>
      </div>

      <div :class="{ 'invalid-form': $v.QuestionFr.$error }" class="form-group">
        <label for="question_fr">Frage in Französisch</label>
        <input
          id="question_fr"
          v-model="QuestionFr"
          @blur="$v.QuestionFr.$touch()"
          type="text"
          class="form-control"
          placeholder="Deine Frage in Französisch"
        />
        <div class="error-messages">
          <p v-if="!$v.QuestionFr.required && $v.QuestionFr.$dirty">Bitte eine Frage eingeben</p>
        </div>
      </div>

      <div :class="{ 'invalid-form': $v.AnswerDe.$error }" class="form-group">
        <label for="answer_de">Antwort Deutsch</label>
        <vue-editor
          id="answer_de"
          v-model="AnswerDe"
          :editor-options="optionsEditor"
          :editor-toolbar="customToolbar"
          @blur="$v.AnswerDe.$touch()"
          class="html-editor"
        ></vue-editor>

        <div class="error-messages">
          <p v-if="!$v.AnswerDe.required && $v.AnswerDe.$dirty">
            Es brauch eine Antwort auf die Frage
          </p>
        </div>
      </div>

      <div :class="{ 'invalid-form': $v.AnswerFr.$error }" class="form-group">
        <label for="answer_fr">Antwort Französisch</label>
        <vue-editor
          id="answer_fr"
          v-model="AnswerFr"
          :editor-options="optionsEditor"
          :editor-toolbar="customToolbar"
          @blur="$v.AnswerFr.$touch()"
          class="html-editor"
        ></vue-editor>

        <div class="error-messages">
          <p v-if="!$v.AnswerFr.required && $v.AnswerFr.$dirty">
            Es brauch eine Antwort auf die Frage
          </p>
        </div>
      </div>

      <button type="submit" class="btn btn-primary">Bestätigen</button>
    </form>
  </div>
</template>

<script>
import auth from 'utils/auth'
import ImageResize from 'quill-image-resize-module-mended'
import { VueEditor, Quill } from 'vue2-editor'
import { required } from 'vuelidate/lib/validators'

Quill.register('modules/imageResize', ImageResize)

export default {
  components: {
    VueEditor
  },
  data() {
    return {
      errors: [],
      isSubmitted: false,
      QuestionDe: '',
      QuestionFr: '',
      AnswerDe: '',
      AnswerFr: '',
      Category: 'default',
      optionsEditor: {
        formats: ['bold', 'underline', 'italic', 'list', 'link', 'header', 'image'],
        modules: {
          imageResize: {}
        }
      },
      customToolbar: [
        ['bold', 'italic', 'underline', 'link'],
        [{ list: 'ordered' }, { list: 'bullet' }, { header: ['3', '4'] }],
        ['image']
      ]
    }
  },

  validations: {
    QuestionDe: {
      required
    },
    QuestionFr: {
      required
    },
    AnswerDe: {
      required
    },
    AnswerFr: {
      required
    }
  },

  mounted() {
    auth
      .get(`faq/${this.$route.params.id}`)
      .then(response => {
        this.QuestionDe = response.data.questionDe
        this.QuestionFr = response.data.questionFr
        this.AnswerDe = response.data.answerDe
        this.AnswerFr = response.data.answerFr
        this.Category = response.data.category
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
          QuestionDe: this.QuestionDe,
          QuestionFr: this.QuestionFr,
          AnswerDe: this.AnswerDe,
          AnswerFr: this.AnswerFr,
          Category: this.Category
        }

        let form_data = new FormData()

        for (var key in formData) {
          form_data.append(key, formData[key])
        }

        auth
          .put(`faq/${this.$route.params.id}`, form_data)
          .then(() => {
            this.isSubmitted = true
          })
          .catch(e => {
            this.errors.push(e)
          })
      }
    },
    handleImageAdded: function(file, Editor, cursorLocation, resetUploader) {
      let formData = new FormData()
      formData.append('File', file)

      auth
        .post('file/faq', formData)
        .then(result => {
          const url = result.data
          window.console.log(url)
          Editor.insertEmbed(cursorLocation, 'image', url)
          resetUploader()
        })
        .catch(() => {})
    }
  }
}
</script>

<style lang="scss" scoped>
.html-editor {
  background-color: white;
}
</style>
