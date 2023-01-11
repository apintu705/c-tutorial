export default {
  async registerCoach(context, payload) {
    const userId = context.rootGetters.userId;
    const coachData = {
      firstName: payload.firstName,
      lastName: payload.lastName,
      hourlyRate: payload.hourlyRate,
      areas: payload.areas,
      description: payload.description,
    };
    const res = await fetch(
      `https://vue-http-18998-default-rtdb.firebaseio.com/coaches/${userId}.json`,
      {
        method: 'PUT',
        body: JSON.stringify(coachData),
      }
    );
    const responseData = await res.json();
    if (!res.ok) {
      return;
    }
    context.commit('registerCoach', {
      ...responseData,
      id: userId,
    });
  },
  async laodCoaches(context,payload) {
    if(!payload.forceRefresh && !context.getters.shouldUpdate){
      return;
    }
    const res = await fetch(
      `https://vue-http-18998-default-rtdb.firebaseio.com/coaches.json`,
      {
        method: 'GET',
      }
    );
    const data = await res.json();
    if (!res.ok) {
      const error = new Error(data.message || 'Failed to fetch coaches');
      throw error;
    }
    const coaches = [];
    for (const key in data) {
      const coach = {
        id: key,
        firstName: data[key].firstName,
        lastName: data[key].lastName,
        hourlyRate: data[key].hourlyRate,
        areas: data[key].areas,
        description: data[key].description,
      };
      coaches.push(coach);
    }
    context.commit('setCoaches', coaches);
    context.commit('setFetchTimestamp')
  },
};
