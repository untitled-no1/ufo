<?xml version="1.0" encoding="utf-8"?>
<wsdl:definitions xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/" xmlns:tns="http://ufo.untitled-no1.at/webservice/" xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" xmlns:s="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/" targetNamespace="http://ufo.untitled-no1.at/webservice/" xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">
  <wsdl:types>
    <s:schema elementFormDefault="qualified" targetNamespace="http://ufo.untitled-no1.at/webservice/">
      <s:element name="HelloWorld">
        <s:complexType />
      </s:element>
      <s:element name="HelloWorldResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="HelloWorldResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
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
      <s:element name="GetNextArtistsPage">
        <s:complexType />
      </s:element>
      <s:element name="GetNextArtistsPageResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetNextArtistsPageResult" type="tns:ArrayOfArtist" />
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
      <s:element name="GetNextVenuesPage">
        <s:complexType />
      </s:element>
      <s:element name="GetNextVenuesPageResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetNextVenuesPageResult" type="tns:ArrayOfVenue" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfVenue">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="Venue" nillable="true" type="tns:Venue" />
        </s:sequence>
      </s:complexType>
      <s:element name="GetNextPerformancesPage">
        <s:complexType />
      </s:element>
      <s:element name="GetNextPerformancesPageResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetNextPerformancesPageResult" type="tns:ArrayOfPerformance" />
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
    </s:schema>
  </wsdl:types>
  <wsdl:message name="HelloWorldSoapIn">
    <wsdl:part name="parameters" element="tns:HelloWorld" />
  </wsdl:message>
  <wsdl:message name="HelloWorldSoapOut">
    <wsdl:part name="parameters" element="tns:HelloWorldResponse" />
  </wsdl:message>
  <wsdl:message name="GetArtistByNameSoapIn">
    <wsdl:part name="parameters" element="tns:GetArtistByName" />
  </wsdl:message>
  <wsdl:message name="GetArtistByNameSoapOut">
    <wsdl:part name="parameters" element="tns:GetArtistByNameResponse" />
  </wsdl:message>
  <wsdl:message name="GetNextArtistsPageSoapIn">
    <wsdl:part name="parameters" element="tns:GetNextArtistsPage" />
  </wsdl:message>
  <wsdl:message name="GetNextArtistsPageSoapOut">
    <wsdl:part name="parameters" element="tns:GetNextArtistsPageResponse" />
  </wsdl:message>
  <wsdl:message name="GetVenueByIdSoapIn">
    <wsdl:part name="parameters" element="tns:GetVenueById" />
  </wsdl:message>
  <wsdl:message name="GetVenueByIdSoapOut">
    <wsdl:part name="parameters" element="tns:GetVenueByIdResponse" />
  </wsdl:message>
  <wsdl:message name="GetNextVenuesPageSoapIn">
    <wsdl:part name="parameters" element="tns:GetNextVenuesPage" />
  </wsdl:message>
  <wsdl:message name="GetNextVenuesPageSoapOut">
    <wsdl:part name="parameters" element="tns:GetNextVenuesPageResponse" />
  </wsdl:message>
  <wsdl:message name="GetNextPerformancesPageSoapIn">
    <wsdl:part name="parameters" element="tns:GetNextPerformancesPage" />
  </wsdl:message>
  <wsdl:message name="GetNextPerformancesPageSoapOut">
    <wsdl:part name="parameters" element="tns:GetNextPerformancesPageResponse" />
  </wsdl:message>
  <wsdl:portType name="DataWebServiceSoap">
    <wsdl:operation name="HelloWorld">
      <wsdl:input message="tns:HelloWorldSoapIn" />
      <wsdl:output message="tns:HelloWorldSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetArtistByName">
      <wsdl:input message="tns:GetArtistByNameSoapIn" />
      <wsdl:output message="tns:GetArtistByNameSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetNextArtistsPage">
      <wsdl:input message="tns:GetNextArtistsPageSoapIn" />
      <wsdl:output message="tns:GetNextArtistsPageSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetVenueById">
      <wsdl:input message="tns:GetVenueByIdSoapIn" />
      <wsdl:output message="tns:GetVenueByIdSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetNextVenuesPage">
      <wsdl:input message="tns:GetNextVenuesPageSoapIn" />
      <wsdl:output message="tns:GetNextVenuesPageSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="GetNextPerformancesPage">
      <wsdl:input message="tns:GetNextPerformancesPageSoapIn" />
      <wsdl:output message="tns:GetNextPerformancesPageSoapOut" />
    </wsdl:operation>
  </wsdl:portType>
  <wsdl:binding name="DataWebServiceSoap" type="tns:DataWebServiceSoap">
    <soap:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="HelloWorld">
      <soap:operation soapAction="http://ufo.untitled-no1.at/webservice/HelloWorld" style="document" />
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
    <wsdl:operation name="GetNextArtistsPage">
      <soap:operation soapAction="http://ufo.untitled-no1.at/webservice/GetNextArtistsPage" style="document" />
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
    <wsdl:operation name="GetNextVenuesPage">
      <soap:operation soapAction="http://ufo.untitled-no1.at/webservice/GetNextVenuesPage" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetNextPerformancesPage">
      <soap:operation soapAction="http://ufo.untitled-no1.at/webservice/GetNextPerformancesPage" style="document" />
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
    <wsdl:operation name="HelloWorld">
      <soap12:operation soapAction="http://ufo.untitled-no1.at/webservice/HelloWorld" style="document" />
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
    <wsdl:operation name="GetNextArtistsPage">
      <soap12:operation soapAction="http://ufo.untitled-no1.at/webservice/GetNextArtistsPage" style="document" />
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
    <wsdl:operation name="GetNextVenuesPage">
      <soap12:operation soapAction="http://ufo.untitled-no1.at/webservice/GetNextVenuesPage" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="GetNextPerformancesPage">
      <soap12:operation soapAction="http://ufo.untitled-no1.at/webservice/GetNextPerformancesPage" style="document" />
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