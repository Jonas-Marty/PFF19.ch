<template>
  <div id="signin">
    <div v-if="getError" class="alert alert-danger">{{ getError }}</div>
    <div class="signin-form">
      <form @submit.prevent="onSubmit">
        <div class="form-group">
          <label for="email">Mail</label>
          <input type="email" id="email" class="form-control" v-model="email">
        </div>
        <div class="form-group">
          <label for="password">Password</label>
          <input type="password" id="password" v-model="password" class="form-control">
        </div>
        <div class="submit">
          <button type="submit" class="btn btn-primary">Submit</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'

export default {
  data() {
    return {
      email: '',
      password: ''
    }
  },
  computed: {
    ...mapGetters('api', ['getError'])
  },
  methods: {
    ...mapActions('api', ['login']),

    onSubmit() {
      const formData = {
        email: this.email,
        password: this.password
      }
      this.login({ email: formData.email, password: formData.password })
    }
  }
}
</script>

<style scoped>
.signin-form {
  width: 400px;
  margin: 50px auto;
  border: 1px solid #eee;
  padding: 20px;
  box-shadow: 0 2px 3px #ccc;
  background: white;
}
</style>
