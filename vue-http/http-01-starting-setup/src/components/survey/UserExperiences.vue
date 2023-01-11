<template>
  <section>
    <base-card>
      <h2>Submitted Experiences</h2>
      <div>
        <base-button @click="loadExperience"
          >Load Submitted Experiences</base-button
        >
      </div>
      <p v-if="isLoading">Loading.....</p>
      <p v-else-if="!isLoading && error">{{ error }}</p>
      <p v-else-if="results.length < 1">
        No stored experiences found. Start addig some sorvey results
      </p>
      <ul v-else-if="!isLoading && results && results.length > 0">
        <survey-result
          v-for="result in results"
          :key="result.id"
          :name="result.name"
          :rating="result.rating"
        ></survey-result>
      </ul>
    </base-card>
  </section>
</template>

<script>
import SurveyResult from './SurveyResult.vue';

export default {
  // props: ['results'],
  components: {
    SurveyResult,
  },
  data() {
    return {
      results: [],
      isLoading: false,
      error: null,
    };
  },
  methods: {
    loadExperience() {
      this.isLoading = true;
      this.error = null;
      fetch('https://vue-http-18998-default-rtdb.firebaseio.com/surveys.json', {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      }) //.then(data=> data.json()).then(data=> console.log(data));
        .then((response) => {
          if (response.ok) {
            return response.json();
          }
        })
        .then((data) => {
          // console.log(data);
          const results = [];
          for (const id in data) {
            results.push({
              id: id,
              name: data[id].name,
              rating: data[id].rating,
            });
          }
          this.isLoading = false;
          this.results = results;
        })
        .catch((error) => 
        {this.isLoading = false;this.error = error.message});
    },
  },
  mounted() {
    this.loadExperience();
  },
};
</script>

<style scoped>
ul {
  list-style: none;
  margin: 0;
  padding: 0;
}
</style>
