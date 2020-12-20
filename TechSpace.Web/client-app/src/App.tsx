import React, { FunctionComponent } from "react";
import { ProvideSpaces } from './hooks/spaces.context';
import { HomePage } from "./components/home-page/home-page.component";

import './tailwind.output.css';
import { ProvideActiveSpace } from "./hooks/active-space.context";

const App: FunctionComponent = () => {
  return (
    <ProvideSpaces>
      <ProvideActiveSpace>
        <HomePage />
      </ProvideActiveSpace>
    </ProvideSpaces>
  );
}

export default App;
