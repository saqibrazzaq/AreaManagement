import Common from "../utility/Common";
import { CityRes } from "./City";
import { PagedReq } from "./PagedReq";

export interface AreaRes {
  areaId?: number;
  name?: string;
  code?: string;
  cityId?: number;

  city?: CityRes;
}

export class AreaReqEdit {
  name?: string;
  code?: string;
  cityId?: number;

  constructor(cityId?: number) {
    this.cityId = cityId;
  }
}

export class AreaReqSearch extends PagedReq {
  cityId?: number;

  constructor(
    {
      pageNumber = 1,
      pageSize = Common.DEFAULT_PAGE_SIZE,
      orderBy,
      searchText = "",
    }: PagedReq,
    cityId = 0
  ) {
    super({
      pageNumber: pageNumber,
      pageSize: pageSize,
      orderBy: orderBy,
      searchText: searchText,
    });
    this.cityId = cityId;
  }
}
