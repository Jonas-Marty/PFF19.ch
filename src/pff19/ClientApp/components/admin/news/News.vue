<template>
  <div>
    <h1>Alle News</h1>
    <router-link to="news/add"> <i class="fa fa-add fa-1x pull-right"></i>hinzufügen </router-link>
    <div class="list-group">
      <div
        v-for="news in all"
        :key="news.id"
        class="list-group-item d-flex justify-content-between align-items-right"
      >
        <div>{{ news.id }}</div>
        <div>{{ news.titleDe }}</div>
        <div>
          <i @click="remove(news.id)" class="fa fa-remove fa-1x pull-right"></i>
          <router-link :to="{ name: 'adminNewsEdit', params: { id: news.id } }">
            <i class="fa fa-edit fa-1x pull-right"></i>
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapActions, mapGetters } from 'vuex'

export default {
  computed: {
    ...mapGetters('news', ['all'])
  },

  created() {
    this.load()
  },
  methods: {
    ...mapActions('news', ['load', 'remove'])
  }
}
</script>

<style lang="scss" scoped>
.fa-remove {
  cursor: pointer;
}

.fa-edit {
  margin-right: 5px;
}
</style>
