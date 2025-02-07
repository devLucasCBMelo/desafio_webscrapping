import { Footer } from "../../components/Footer/Footer";
import { Header } from "../../components/Header/Header";
import { LoginContainer, LoginForm, LoginMain } from "./styles";

function Login() {
  return (
    <LoginContainer>
      <Header />
      <LoginMain>
        <h1>Composição de Alimentos (em medidas caseiras)</h1>
        <LoginForm>
          <label htmlFor="input-email">
            E-mail
            <input id="input-email" type="email"  placeholder="Digite seu e-mail"/>
          </label>
          <label htmlFor="input-password">
            Senha
            <input id="input-password" type="password" placeholder="Digte sua senha"/>
          </label>
          <button type="submit">Entrar</button>
        </LoginForm>
      </LoginMain>
      <Footer />
    </LoginContainer>
  )
}

export default Login;