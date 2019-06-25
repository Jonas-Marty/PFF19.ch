<template>
  <div>
    <h1>Alle News</h1>
    <router-link to="news/add"> <i class="fa fa-add fa-1x pull-right"></i>hinzufügen </router-link>
    <div class="list-group">
      <div
        class="list-group-item d-flex justify-content-between align-items-right"
        v-for="news in all"
        :key="news.id"
      >
        <div>
          {{ news.id }}
        </div>
        <div>
          {{ news.titleDe }}
        </div>
        <div>
          <i class="fa fa-remove fa-1x pull-right" @click="remove(news.id)"></i>
          <router-link :to="{ name: 'adminNewsEdit', params: { id: news.id } }"
            ><i class="fa fa-edit fa-1x pull-right"></i
          ></router-link>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapActions, mapGetters } from 'vuex'
import axios from 'axios'

export default {
  methods: {
    ...mapActions('news', ['load', 'remove'])
  },

  computed: {
    ...mapGetters('news', ['all'])
  },

  created() {
    this.load()
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
