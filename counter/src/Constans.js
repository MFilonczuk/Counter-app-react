const API_BASE_URL_DEVELPOMENT = "https://localhost:7062";

const ENDPOINTS = {
    GET_NUMBER: "api/Count/get-number",
    POST_NUMBER: "api/Count/post-number",
    RESET_NUMBER: "api/Count/reset-number?id=1",
    DECREMENT_NUMBER: "api/Count/decrease-number?id=1",
    INCREMENT_NUMBER: "api/Count/increase-number?id=1"
}

const development = {
    API_URL_GET_NUMBER: `${API_BASE_URL_DEVELPOMENT}/${ENDPOINTS.GET_NUMBER}`,
    API_URL_POST_NUMBER: `${API_BASE_URL_DEVELPOMENT}/${ENDPOINTS.POST_NUMBER}`,
    API_URL_RESET_NUMBER: `${API_BASE_URL_DEVELPOMENT}/${ENDPOINTS.RESET_NUMBER}`,
    API_URL_DECREMENT_NUMBER: `${API_BASE_URL_DEVELPOMENT}/${ENDPOINTS.DECREMENT_NUMBER}`,
    API_URL_INCREMENT_NUMBER: `${API_BASE_URL_DEVELPOMENT}/${ENDPOINTS.INCREMENT_NUMBER}`
}

const Constants = process.env.NODE_ENV === "development" ? development : null;

export default Constants;