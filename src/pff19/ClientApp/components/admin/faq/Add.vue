<template>
                <div>
                    <h2 class="title">FAQ hinzufügen</h2>
                    <div v-if="isSubmitted">
                        <p>Die FAQ wurde hinzugefügt!</p>
                        <router-link
                        :to="{name: 'adminFAQs'}"
                        >Zurück</router-link>
                    </div>
                   <form @submit.prevent="submit" v-if="!isSubmitted">

                    <div class="form-group" :class="{'invalid-form': $v.QuestionDe.$error}">
                        <label for="question_de">Frage in Deutsch</label>
                        <input 
                            type="text" 
                            @blur="$v.QuestionDe.$touch()" 
                            class="form-control" 
                            id="question_de" 
                            placeholder="Deine Frage in Deutsch" 
                            v-model="QuestionDe"
                        >
                        <div class="error-messages">
                            <p v-if="!$v.QuestionDe.required && $v.QuestionDe.$dirty">Bitte eine Frage eingeben</p>
                            <p v-if="!$v.QuestionDe.required && $v.QuestionDe.$dirty">Deine Frage ist zu kurz</p>
                            <p v-if="!$v.QuestionDe.required && $v.QuestionDe.$dirty">Deine Frage ist zu lang</p>
                        </div>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.QuestionFr.$error}">
                        <label for="question_fr">Frage in Französisch</label>
                        <input 
                            type="text" 
                            @blur="$v.QuestionFr.$touch()" 
                            class="form-control" 
                            id="question_fr" 
                            placeholder="Deine Frage in Französisch" 
                            v-model="QuestionFr"
                        >
                        <div class="error-messages">
                            <p v-if="!$v.QuestionFr.required && $v.QuestionFr.$dirty">Bitte eine Frage eingeben</p>
                            <p v-if="!$v.QuestionFr.required && $v.QuestionFr.$dirty">Deine Frage ist zu kurz</p>
                            <p v-if="!$v.QuestionFr.required && $v.QuestionFr.$dirty">Deine Frage ist zu lang</p>
                        </div>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.AnswerDe.$error}">
                        <label for="answer_de">Antwort Deutsch</label>
                        <vue-editor class="html-editor" @blur="$v.AnswerDe.$touch()" id="answer_de" :editorToolbar="customToolbar" v-model="AnswerDe"></vue-editor>

                        <div class="error-messages"> 
                            <p v-if="!$v.AnswerDe.required && $v.AnswerDe.$dirty">Es brauch eine Antwort auf die Frage</p>
                        </div>
                    </div>

                    <div class="form-group" :class="{'invalid-form': $v.AnswerFr.$error}">
                        <label for="answer_fr">Antwort Französisch</label>
                        <vue-editor class="html-editor" @blur="$v.AnswerFr.$touch()" id="answer_fr" :editorToolbar="customToolbar" v-model="AnswerFr"></vue-editor>

                        <div class="error-messages"> 
                            <p v-if="!$v.AnswerFr.required && $v.AnswerFr.$dirty">Es brauch eine Antwort auf die Frage</p>
                        </div>
                    </div>

                    <button type="submit" class="btn btn-primary" >Bestätigen</button>
                </form>
            </div>

</template>

<script>
import auth from '../../../auth.js'
import { VueEditor } from "vue2-editor"
import { required, maxLength, minLength } from 'vuelidate/lib/validators'


export default {
    data () {
        return {
            errors: [],
            isSubmitted: false,
            QuestionDe: '',
            QuestionFr: '',
            AnswerDe: '',
            AnswerFr: '',
            Category: '',

            customToolbar: [
                ['bold', 'italic', 'underline', 'link'],
                [{ 'list': 'ordered'}, { 'list': 'bullet' }, {'header': ['3','4']}],
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
        VueEditor
    },

    validations: {
        QuestionDe: {
            required,
            minLength: minLength(3),
            maxLength: maxLength(255)
        },
        QuestionFr: {
            required,
            minLength: minLength(3),
            maxLength: maxLength(255)
        },
        AnswerDe: {
            required        
        },
        AnswerFr: {
            required        
        }

    },

    methods: {
        submit () {
            this.$v.$touch();
            if(!this.$v.$invalid){

                const formData = {
                    QuestionDe: this.QuestionDe,
                    QuestionFr: this.QuestionFr,
                    AnswerDe: this.AnswerDe,
                    AnswerFr: this.AnswerFr,
                    Category: this.Category,
                    Order: this.Order,
                }

                let form_data = new FormData()

                for ( var key in formData ) {
                    form_data.append(key, formData[key])
                }

                auth.post('faq', form_data)
                .then(response => {
                    this.isSubmitted = true;
                }).catch(e => {
                    this.errors.push(e)
                })
            }

      }     
    }

}
</script>

<style lang="scss" scoped>
    .html-editor{
        background-color: white;
    }
</style>