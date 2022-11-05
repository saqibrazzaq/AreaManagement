import { api } from "./axiosconfig"
import { defineCancelApiObject } from "./axiosUtils"

export const AreaApi = {
  get: async function (areaId, cancel = false) {
    const response = await api.request({
      url: `/areas/` + areaId,
      method: "GET",
      // retrieving the signal value by using the property name
      signal: cancel ? cancelApiObject[this.get.name].handleRequestCancellation().signal : undefined,
    })

    return response.data
  },
  search: async function (searchParams, cancel = false) {
    // console.log(searchParams)
    const response = await api.request({
      url: "/areas/search",
      method: "GET",
      params: searchParams,
      signal: cancel ? cancelApiObject[this.search.name].handleRequestCancellation().signal : undefined,
    })

    return response.data
  },
  create: async function (area, cancel = false) {
    const response = await api.request({
      url: `/areas`,
      method: "POST",
      data: area,
      signal: cancel ? cancelApiObject[this.create.name].handleRequestCancellation().signal : undefined,
    })

    return response.data
  },
  update: async function (areaId, area, cancel = false) {
    await api.request({
      url: `/areas/` + areaId,
      method: "PUT",
      data: area,
      signal: cancel ? cancelApiObject[this.update.name].handleRequestCancellation().signal : undefined,
    })
  },
  delete: async function (areaId, cancel = false) {
    const response = await api.request({
      url: `/areas/` + areaId,
      method: "DELETE",
      // retrieving the signal value by using the property name
      signal: cancel ? cancelApiObject[this.delete.name].handleRequestCancellation().signal : undefined,
    })

    return response.data
  },
  count: async function (cancel = false) {
    const response = await api.request({
      url: "/areas/count",
      method: "GET",
      signal: cancel ? cancelApiObject[this.count.name].handleRequestCancellation().signal : undefined,
    })

    return response.data
  },
}

// defining the cancel API object for ProductAPI
const cancelApiObject = defineCancelApiObject(AreaApi)
