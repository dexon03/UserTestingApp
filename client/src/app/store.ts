import { configureStore } from '@reduxjs/toolkit'
import { setupListeners } from '@reduxjs/toolkit/dist/query/react'
import { testApi } from './features/tests/test.api';

export const store = configureStore({
  reducer: {
    [testApi.reducerPath]: testApi.reducer,
  },
  middleware(getDefaultMiddleware) {
    return getDefaultMiddleware().concat(testApi.middleware);
  },
})

setupListeners(store.dispatch)


export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch