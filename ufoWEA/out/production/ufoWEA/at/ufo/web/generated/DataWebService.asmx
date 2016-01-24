<?xml version="1.0" encoding="utf-8"?>
<wsdl:definitions xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/" xmlns:tns="http://ufo.untitled-no1.at/webservice/" xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" xmlns:s="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/" targetNamespace="http://ufo.untitled-no1.at/webservice/" xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">
  <wsdl:types>
    <s:schema elementFormDefault="qualified" targetNamespace="http://ufo.untitled-no1.at/webservice/">
      <s:element name="LogIn">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="user" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="passwordHash" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LogInResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="LogInResult" type="tns:User" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="User">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="UserId" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="FirstName" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="LastName" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="EMail" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Password" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="IsAdmin" type="s:boolean" />
          <s:element minOccurs="1" maxOccurs="1" name="IsArtist" type="s:boolean" />
          <s:element minOccurs="0" maxOccurs="1" name="Artist" type="tns:Artist" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="Artist">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="ArtistId" type="s:int" />
          <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="EMail" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Category" type="tns:Category" />
          <s:element minOccurs="0" maxOccurs="1" name="Country" type="tns:Country" />
          <s:element minOccurs="0" maxOccurs="1" name="Picture" type="tns:BlobData" />
          <s:element minOccurs="0" maxOccurs="1" name="PromoVideo" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="Category">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="CategoryId" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Color" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="Country">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="Code" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="BlobData">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Path" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="DataStream" type="s:base64Binary" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetArtistByName">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="name" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetArtistByNameResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetArtistByNameResult" type="tns:Artist" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetArtistById">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="id" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetArtistByIdResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetArtistByIdResult" type="tns:Artist" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetArtistsPage">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ArtistPage" type="tns:Page" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="Page">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="Offset" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="Size" type="s:int" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetArtistsPageResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetArtistsPageResult" type="tns:ArrayOfArtist" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfArtist">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="Artist" nillable="true" type="tns:Artist" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetVenueById">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="id" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetVenueByIdResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetVenueByIdResult" type="tns:Venue" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="Venue">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="VenueId" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Location" type="tns:Location" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="Location">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="LocationId" type="s:int" />
          <s:element minOccurs="1" maxOccurs="1" name="Longitude" type="s:decimal" />
          <s:element minOccurs="1" maxOccurs="1" name="Latitude" type="s:decimal" />
          <s:element minOccurs="0" maxOccurs="1" name="Name" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetVenuesPage">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="VenuePage" type="tns:Page" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetVenuesPageResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetVenuesPageResult" type="tns:ArrayOfVenue" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfVenue">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="Venue" nillable="true" type="tns:Venue" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetPerformancesPage">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="PerformancePage" type="tns:Page" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetPerformancesPageResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetPerformancesPageResult" type="tns:ArrayOfPerformance" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfPerformance">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="Performance" nillable="true" type="tns:Performance" />
        </s:sequence>
      </s:complexType>
      <s:complexType name="Performance">
        <s:sequence>
          <s:element minOccurs="1" maxOccurs="1" name="DateTime" type="s:dateTime" />
          <s:element minOccurs="0" maxOccurs="1" name="Artist" type="tns:Artist" />
          <s:element minOccurs="0" maxOccurs="1" name="Venue" type="tns:Venue" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetAllPerformanceDates">
        <s:complexType />
      </s:element>
      <s:element name="GetAllPerformanceDatesResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetAllPerformanceDatesResult" type="tns:ArrayOfString" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfString">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="string" nillable="true" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="getPerformancesPerArtist">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="id" type="s:int" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getPerformancesPerArtistResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="getPerformancesPerArtistResult" type="tns:ArrayOfPerformance" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getPerformancesPerVenue">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="id" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="getPerformancesPerVenueResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="getPerformancesPerVenueResult" type="tns:ArrayOfPerformance" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetPerformancesPerDate">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="d" type="s:dateTime" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetPerformancesPerDateResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetPerformancesPerDateResult" type="tns:ArrayOfPerformance" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="deletePerformance">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="u" type="tns:User" />
            <s:element minOccurs="0" maxOccurs="1" name="p" type="tns:Performance" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="deletePerformanceResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="deletePerformanceResult" type="s:boolean" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="UpdatePerformance">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="u" type="tns:User" />
            <s:element minOccurs="0" maxOccurs="1" name="oldPerformance" type="tns:Performance" />
            <s:element minOccurs="0" maxOccurs="1" name="newPerformance" type="tns:Performance" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="UpdatePerformanceResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="UpdatePerformanceResult" type="s:boolean" />
          </s:sequence>
        </s:complexType>
      </s:element>
    </s:schema>
  </wsdl:types>
  <wsdl:message name="LogInSoapIn">
    <wsdl:part name="parameters" element="tns:LogIn" />
  </wsdl:message>
  <wsdl:message name="LogInSoapOut">
    <wsdl:part name="parameters" element="tns:LogInResponse" />
  </wsdl:message>
  <wsdl:message name="GetArtistByNameSoapIn">
    <wsdl:part name="parameters" element="tns:GetArtistByName" />
  </wsdl:message>
  <wsdl:message name="GetArtistByNameSoapOut">
    <wsdl:part name="parameters" element="tns:GetArtistByNameResponse" />
  </wsdl:message>
  <wsdl:message name="GetArtistByIdSoapIn">
    <wsdl:part name="parameters" element="tns:GetArtistById" />
  </wsdl:message>
  <wsdl:message name="GetArtistByIdSoapOut">
    <wsdl:part name="parameters" element="tns:GetArtistByIdResponse" />
  </wsdl:message>
  <wsdl:message name="GetArtistsPageSoapIn">
    <wsdl:part name="parameters" element="tns:GetArtistsPage" />
  </wsdl:message>
  <wsdl:message name="GetArtistsPageSoapOut">
    <wsdl:part name="parameters" element="tns:GetArtistsPageResponse" />
  </wsdl:message>
  <wsdl:message name="GetVenueByIdSoapIn">
    <wsdl:part name="parameters" element="tns:GetVenueById" />
  </wsdl:message>
  <wsdl:message name="GetVenueByIdSoapOut">
    <wsdl:part name="parameters" element="tns:GetVenueByIdResponse" />
  </wsdl:message>
  <wsdl:message name="GetVenuesPageSoapIn">
    <wsdl:part name="parameters" element="tns:GetVenuesPage" />
  </wsdl:message>
  <wsdl:message name="GetVenuesPageSoapOut">
    <wsdl:part name="parameters" element="tns:GetVenuesPageResponse" />
  </wsdl:message>
  <wsdl:message name="GetPerformancesPageSoapIn">
    <wsdl:part name="parameters" element="tns:GetPerformancesPage" />
  </wsdl:message>
  <wsdl:message name="GetPerformancesPageSoapOut">
    <wsdl:part name="parameters" element="tns:GetPerformancesPageResponse" />
  </wsdl:message>
  <wsdl:message name="GetAllPerformanceDatesSoapIn">
    <wsdl:part name="parameters" element="tns:GetAllPerformanceDates" />
  </wsdl:message>
  <wsdl:message name="GetAllPerformanceDatesSoapOut">
    <wsdl:part name="parameters" element="tns:GetAllPerformanceDatesResponse" />
  </wsdl:message>
  <wsdl:message name="getPerformancesPerArtistSoapIn">
    <wsdl:part name="parameters" element="tns:getPerformancesPerArtist" />
  </wsdl:message>
  <wsdl:message name="getPerformancesPerArtistSoapOut">
    <wsdl:part name="parameters" element="tns:getPerformancesPerArtistResponse" />
  </wsdl:message>
  <wsdl:message name="getPerformancesPerVenueSoapIn">
    <wsdl:part name="parameters" element="tns:getPerformancesPerVenue" />
  </wsdl:message>
  <wsdl:message name="getPerformancesPerVenueSoapOut">
    <wsdl:part name="parameters" element="tns:getPerformancesPerVenueResponse" />
  </wsdl:message>
  <wsdl:message name="GetPerformancesPerDateSoapIn">
    <wsdl:part name="parameters" element="tns:GetPerformancesPerDate" />
  </wsdl:message>
  <wsdl:message name="GetPerformancesPerDateSoapOut">
    <wsdl:part name="parameters" element="tns:GetPerformancesPerDateResponse" />
  </wsdl:message>
  <wsdl:message name="deletePerformanceSoapIn">
    <wsdl:part name="parameters" element="tns:deletePerformance" />
  </wsdl:message>
  <wsdl:message name="deletePerformanceSoapOut">
    <wsdl:part name="parameters" element="tns:deletePerformanceResponse" />
  </wsdl:message>
  <wsdl:message name="UpdatePerformanceSoapIn">
    <wsdl:part name="parameters" element="tns:UpdatePerformance" />
  </wsdl:message>
  <wsdl:message name="UpdatePerformanceSoapOut">
    <wsdl:part name="parameters" element="tns:UpdatePerformanceResponse" />
  </wsdl:message>
  <wsdl:portType name="DataWebServiceSoap">
    <wsdl:operation name="LogIn">
      <wsdl:input message="tns:LogInSoapIn" />
      <wsdl:output message="tns:LogInSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetArtistByName">
      <wsdl:input message="tns:GetArtistByNameSoapIn" />
      <wsdl:output message="tns:GetArtistByNameSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetArtistById">
      <wsdl:input message="tns:GetArtistByIdSoapIn" />
      <wsdl:output message="tns:GetArtistByIdSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetArtistsPage">
      <wsdl:input message="tns:GetArtistsPageSoapIn" />
      <wsdl:output message="tns:GetArtistsPageSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetVenueById">
      <wsdl:input message="tns:GetVenueByIdSoapIn" />
      <wsdl:output message="tns:GetVenueByIdSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetVenuesPage">
      <wsdl:input message="tns:GetVenuesPageSoapIn" />
      <wsdl:output message="tns:GetVenuesPageSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetPerformancesPage">
      <wsdl:input message="tns:GetPerformancesPageSoapIn" />
      <wsdl:output message="tns:GetPerformancesPageSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetAllPerformanceDates">
      <wsdl:input message="tns:GetAllPerformanceDatesSoapIn" />
      <wsdl:output message="tns:GetAllPerformanceDatesSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="getPerformancesPerArtist">
      <wsdl:input message="tns:getPerformancesPerArtistSoapIn" />
      <wsdl:output message="tns:getPerformancesPerArtistSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="getPerformancesPerVenue">
      <wsdl:input message="tns:getPerformancesPerVenueSoapIn" />
      <wsdl:output message="tns:getPerformancesPerVenueSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetPerformancesPerDate">
      <wsdl:input message="tns:GetPerformancesPerDateSoapIn" />
      <wsdl:output message="tns:GetPerformancesPerDateSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="deletePerformance">
      <wsdl:input message="tns:deletePerformanceSoapIn" />
      <wsdl:output message="tns:deletePerformanceSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="UpdatePerformance">
      <wsdl:input message="tns:UpdatePerformanceSoapIn" />
      <wsdl:output message="tns:UpdatePerformanceSoapOut" />
    </wsdl:operation>
  </wsdl:portType>
  <wsdl:binding name="DataWebServiceSoap" type="tns:DataWebServiceSoap">
    <soap:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="LogIn">
      <soap:operation soapAction="http://ufo.untitled-no1.at/webservice/LogIn" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetArtistByName">
      <soap:operation soapAction="http://ufo.untitled-no1.at/webservice/GetArtistByName" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetArtistById">
      <soap:operation soapAction="http://ufo.untitled-no1.at/webservice/GetArtistById" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetArtistsPage">
      <soap:operation soapAction="http://ufo.untitled-no1.at/webservice/GetArtistsPage" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetVenueById">
      <soap:operation soapAction="http://ufo.untitled-no1.at/webservice/GetVenueById" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetVenuesPage">
      <soap:operation soapAction="http://ufo.untitled-no1.at/webservice/GetVenuesPage" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetPerformancesPage">
      <soap:operation soapAction="http://ufo.untitled-no1.at/webservice/GetPerformancesPage" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetAllPerformanceDates">
      <soap:operation soapAction="http://ufo.untitled-no1.at/webservice/GetAllPerformanceDates" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getPerformancesPerArtist">
      <soap:operation soapAction="http://ufo.untitled-no1.at/webservice/getPerformancesPerArtist" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getPerformancesPerVenue">
      <soap:operation soapAction="http://ufo.untitled-no1.at/webservice/getPerformancesPerVenue" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetPerformancesPerDate">
      <soap:operation soapAction="http://ufo.untitled-no1.at/webservice/GetPerformancesPerDate" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="deletePerformance">
      <soap:operation soapAction="http://ufo.untitled-no1.at/webservice/deletePerformance" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="UpdatePerformance">
      <soap:operation soapAction="http://ufo.untitled-no1.at/webservice/UpdatePerformance" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:binding name="DataWebServiceSoap12" type="tns:DataWebServiceSoap">
    <soap12:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="LogIn">
      <soap12:operation soapAction="http://ufo.untitled-no1.at/webservice/LogIn" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetArtistByName">
      <soap12:operation soapAction="http://ufo.untitled-no1.at/webservice/GetArtistByName" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetArtistById">
      <soap12:operation soapAction="http://ufo.untitled-no1.at/webservice/GetArtistById" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetArtistsPage">
      <soap12:operation soapAction="http://ufo.untitled-no1.at/webservice/GetArtistsPage" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetVenueById">
      <soap12:operation soapAction="http://ufo.untitled-no1.at/webservice/GetVenueById" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetVenuesPage">
      <soap12:operation soapAction="http://ufo.untitled-no1.at/webservice/GetVenuesPage" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetPerformancesPage">
      <soap12:operation soapAction="http://ufo.untitled-no1.at/webservice/GetPerformancesPage" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetAllPerformanceDates">
      <soap12:operation soapAction="http://ufo.untitled-no1.at/webservice/GetAllPerformanceDates" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getPerformancesPerArtist">
      <soap12:operation soapAction="http://ufo.untitled-no1.at/webservice/getPerformancesPerArtist" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="getPerformancesPerVenue">
      <soap12:operation soapAction="http://ufo.untitled-no1.at/webservice/getPerformancesPerVenue" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetPerformancesPerDate">
      <soap12:operation soapAction="http://ufo.untitled-no1.at/webservice/GetPerformancesPerDate" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="deletePerformance">
      <soap12:operation soapAction="http://ufo.untitled-no1.at/webservice/deletePerformance" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="UpdatePerformance">
      <soap12:operation soapAction="http://ufo.untitled-no1.at/webservice/UpdatePerformance" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:service name="DataWebService">
    <wsdl:port name="DataWebServiceSoap" binding="tns:DataWebServiceSoap">
      <soap:address location="http://localhost:49569/DataWebService.asmx" />
    </wsdl:port>
    <wsdl:port name="DataWebServiceSoap12" binding="tns:DataWebServiceSoap12">
      <soap12:address location="http://localhost:49569/DataWebService.asmx" />
    </wsdl:port>
  </wsdl:service>
</wsdl:definitions>