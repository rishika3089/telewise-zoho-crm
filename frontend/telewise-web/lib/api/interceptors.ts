import axios from "axios";
import { apiClient } from "./client";

apiClient.interceptors.request.use(
  (config) => {
    return config;
  },
  (error) => Promise.reject(error),
);

apiClient.interceptors.response.use(
  (response) => response,
  (error) => {
    if (axios.isAxiosError(error)) {
      console.error(
        "[API ERROR]",
        error.response?.status,
        error.response?.data,
      );
    }

    return Promise.reject(error);
  },
);