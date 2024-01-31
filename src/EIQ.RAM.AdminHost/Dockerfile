FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine
ARG USER=loodos
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN apk add --update sudo
RUN adduser -D $USER \
        && echo "$USER ALL=(ALL) NOPASSWD: ALL" > /etc/sudoers.d/$USER \
        && chmod 0440 /etc/sudoers.d/$USER

USER $USER
WORKDIR /app
COPY . .
ENTRYPOINT ["dotnet", "EIQ.RAM.AdminHost.dll"]