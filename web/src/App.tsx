import { Routes, Route, BrowserRouter } from "react-router-dom";
import AreaDelete from "./area/AreaDelete";
import AreaEdit from "./area/AreaEdit";
import Areas from "./area/Areas";
import Cities from "./city/Cities";
import CityDelete from "./city/CityDelete";
import CityEdit from "./city/CityEdit";
import Countries from "./country/Countries";
import CountryDelete from "./country/CountryDelete";
import CountryEdit from "./country/CountryEdit";
import CountryReset from "./country/CountryReset";
import Layout from "./layout/Layout";
import StateDelete from "./state/StateDelete";
import StateEdit from "./state/StateEdit";
import States from "./state/States";

export const App = () => (
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<Layout />}>
        <Route index element={<Areas />} />
        <Route path="areas">
          <Route index element={<Areas />} />
          <Route path=":cityId" element={<Areas />} />
          <Route path="edit" element={<AreaEdit />} />
          <Route path="edit/:cityId" element={<AreaEdit />} />
          <Route path="edit/:cityId/:areaId" element={<AreaEdit />} />
          <Route path="delete/:cityId/:areaId" element={<AreaDelete />} />
        </Route>
        <Route path="cities">
          <Route index element={<Cities />} />
          <Route path=":stateId" element={<Cities />} />
          <Route path="edit" element={<CityEdit />} />
          <Route path="edit/:stateId" element={<CityEdit />} />
          <Route path="edit/:stateId/:cityId" element={<CityEdit />} />
          <Route path="delete/:stateId/:cityId" element={<CityDelete />} />
        </Route>
        <Route path="states">
          <Route index element={<States />} />
          <Route path=":countryId" element={<States />} />
          <Route path="edit" element={<StateEdit />} />
          <Route path="edit/:countryId" element={<StateEdit />} />
          <Route path="edit/:countryId/:stateId" element={<StateEdit />} />
          <Route path="delete/:countryId/:stateId" element={<StateDelete />} />
        </Route>
        <Route path="countries">
          <Route index element={<Countries />} />
          <Route path="edit" element={<CountryEdit />} />
          <Route path="edit/:countryId" element={<CountryEdit />} />
          <Route path="delete/:countryId" element={<CountryDelete />} />
          <Route path="reset" element={<CountryReset />} />
        </Route>
      </Route>
    </Routes>
  </BrowserRouter>
);
