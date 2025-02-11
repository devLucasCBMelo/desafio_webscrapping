import { useParams } from "react-router-dom";
import { ComponentInfosPageContainer } from "./styles";

function ComponentInfosPage() {
  const {foodCode} = useParams();

  return (
    <ComponentInfosPageContainer>
      <h1>código do alimento: {foodCode}</h1>
    </ComponentInfosPageContainer>
  )
}

export default ComponentInfosPage;